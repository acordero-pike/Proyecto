let id = null;
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();
myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json'); 
document.addEventListener('DOMContentLoaded', mostrar);
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  id =ar.id})
const url  = `https://localhost:5001/api/compra/`+id
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
     console.log(id)
    const listado = document.querySelector('#listado-clientes');

        const Estudiantes = await obtenerestudiantes();
        
        if (Estudiantes.length>0)
       {
        Estudiantes.forEach( est => {
            const { idCompra,fecha,total,cantidad } = est;
            const row = document.createElement('tr');

          
            row.innerHTML += `
            <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
            <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${fecha.split("T")[0]} </p>
            </td>
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                   
                    <p class="text-sm leading-10 text-gray-700"> Q.${total} </p>
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
       }else{
        const row = document.createElement('tr');

          
        row.innerHTML += `
        <td colspan="4" style="text-align: center;" class="px-6 py-4 whitespace-no-wrap border-b border-gray-200"> Sin Resultados</td>
        
        `;

       
        listado.appendChild(row);
       }
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