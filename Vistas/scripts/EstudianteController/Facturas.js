let id = null;
document.addEventListener('DOMContentLoaded', mostrar);
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  id =ar.id})
const url  = `https://localhost:5001/api/compra/`+id
const obtenerestudiantes = async () => {
    try {
        const resultado = await fetch(url);
       
        const estudiante = await resultado.json();
        console.log(estudiante)
       return estudiante;

    } catch (error) {
        console.log(error);
    }
}


 async function mostrar() {
     console.log(id)
    const listado = document.querySelector('#listado-clientes');

        const Estudiantes = await obtenerestudiantes();
        
        Estudiantes.forEach( est => {
            const { idCompra,fecha,total,cantidad } = est;
            const row = document.createElement('tr');

          
            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${fecha} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> ${total} </p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">${cantidad}</p>
                </td>
               
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 text-sm leading-5">
                    <a href="dtll.html?crs=${idCompra}" class="text-teal-600 hover:text-teal-900 mr-5"><button>Detalle</button></a>
                </td>
            `;

           
            listado.appendChild(row);
        })
    }