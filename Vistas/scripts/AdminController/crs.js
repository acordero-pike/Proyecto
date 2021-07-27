
document.addEventListener('DOMContentLoaded', mostrar);


const url  = `https://localhost:5001/api/cursos`
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
    const listado = document.querySelector('#listado-clientes');

        const Estudiantes = await obtenerestudiantes();
        
        Estudiantes.forEach( est => {
            const { idCurso,nombre,descripcion,cantidad  } = est;
            const row = document.createElement('tr');

           if (cantidad>0)
           {
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
               
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 text-sm leading-5">
                <a href="inscritos.html?id=${idCurso}" class="text-teal-600 hover:text-teal-900 mr-5"><button  >Ver Alumnos</button></a>
                </td>
            `;

           }else
           {
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
               
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 text-sm leading-5">
                    <a href="inscritos.html?id=${idCurso}" class="text-teal-600 hover:text-teal-900 mr-5"><button disabled>Ver Alumnos</button></a>
                </td>
            `;

           }
            listado.appendChild(row);
        })
    }