
document.addEventListener('DOMContentLoaded', mostrar);


const url  = `https://localhost:5001/api/cursos/`
const obtenerestudiantes = async () => {
    try {
        let id = null;
        prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
   
        prearray.forEach( ar =>  {  id =ar.id})
        const resultado = await fetch(url+id);
       
        const estudiante = await resultado.json();
        console.log(estudiante)
       return estudiante;

    } catch (error) {
        console.log(error);
    }
}


 async function mostrar() {
    const listado = document.querySelector('#listado-clientes');

        const Estudiantes = await obtenerestudiantes();
        
      if (Estudiantes.length>0)
      {
        Estudiantes.forEach( est => {
            const { idCurso,nombre,descripcion,cantidad,costo ,gan } = est;
            const row = document.createElement('tr');

           
            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${nombre} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> ${descripcion} </p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">${cantidad}</p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                <p class="text-gray-700">Q.${costo/1.2}</p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">Q.${gan}</p>
                </td>
                
            `;

             
            listado.appendChild(row);
        })
      }else{
        const row = document.createElement('tr');

          
        row.innerHTML += `
        <td colspan="5" style="text-align: center;" class="px-6 py-4 whitespace-no-wrap border-b border-gray-200"> Sin Resultados</td>
        
        `;

       
        listado.appendChild(row);
      }
    }