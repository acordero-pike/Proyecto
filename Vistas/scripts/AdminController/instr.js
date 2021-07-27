
 
    const urlc =" https://localhost:5001/api/AdminCrs/"
let idCliente=null;

document.addEventListener('DOMContentLoaded', async () => {
    // Verificar si el cliente existe
    const parametrosURL = new URLSearchParams(window.location.search);
    idCliente = parseInt( parametrosURL.get('id') );

    mostrar();
});


const obtenerestudiantes = async () => {
    try {
        const resultado = await fetch(urlc+idCliente);
       
        const estudiante = await resultado.json();
        console.log(estudiante)
       return estudiante;

    } catch (error) {
        console.log(error);
    }
}



async function mostrar() {
    const listado = document.querySelector('#listado-clientes');

        const Curso = await obtenerestudiantes();
        
        Curso.forEach( est => {
            const { nombre,apellido,correo  } = est;
            const row = document.createElement('tr');

            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${nombre} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> ${apellido}  </p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">${correo}</p>
                </td>
          
            `;

            listado.appendChild(row);
        })
    }