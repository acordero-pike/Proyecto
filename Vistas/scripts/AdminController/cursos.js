const urlc =" https://25.18.168.1/api/Admin/"
let idCliente=null;
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  

document.addEventListener('DOMContentLoaded', async () => {
    // Verificar si el cliente existe
    const parametrosURL = new URLSearchParams(window.location.search);
    idCliente = parseInt( parametrosURL.get('id') );

    mostrar();
});


const obtenerestudiantes = async () => {
    return fetch(urlc+idCliente, {
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

        const Curso = await obtenerestudiantes();
        
        Curso.forEach( est => {
            const { nombre,duracion,instructo  } = est;
            const row = document.createElement('tr');

            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${nombre} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> ${duracion} hrs </p>
                </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                    <p class="text-gray-700">${instructo}</p>
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