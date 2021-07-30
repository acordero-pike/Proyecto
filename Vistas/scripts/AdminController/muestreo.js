

prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
document.addEventListener('DOMContentLoaded', mostrar);


const url  = `https://localhost:5001/api/Admin`
const obtenerestudiantes = async () => {
    return fetch(url, {
        method: "GET"
       ,headers:myHeaders,
      }).then(response => {
  
        if( !response.ok ){
    
            catchError( response );
    
        } else {
    
         return response.json();
    
        }
    
    }).catch( catchError )
}


 async function mostrar() {
    const listado = document.querySelector('#listado-clientes');

        const Estudiantes = await obtenerestudiantes();
        
        Estudiantes.forEach( est => {
            const { idEstudianes ,nombre , apellido  , telefono, correo  } = est;
            const row = document.createElement('tr');

            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${nombre} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> ${apellido} </p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">${telefono}</p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200  leading-5 text-gray-700">    
                    <p class="text-gray-600">${correo}</p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 text-sm leading-5">
                    <a href="vercusrsos.html?id=${idEstudianes}" class="text-teal-600 hover:text-teal-900 mr-5"><button>Ver Cursos</button></a>
                </td>
            `;

            listado.appendChild(row);
        })
    }

    function catchError( error ,msj){

        console.log( error.status );
         
        if (msj==null && error.status==401)
        {
            msj="Algo Salio Mal... ,No tiene permitido el uso de este Recurso";
        }
        else if(msj==null)
        {
           msj="Algo Salio Mal...";
        }
      //   
      window.location.href=`error.html?id=${msj}`;
      
      }