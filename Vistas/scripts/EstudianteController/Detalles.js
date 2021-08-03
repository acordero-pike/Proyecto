
 prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
 prearray.forEach( ar =>  {  token =ar.token})
 
   const myHeaders = new Headers();
 myHeaders.append('Authorization', `Bearer ${token}  `);
 myHeaders.append('Content-Type', 'application/json'); 
    const urlc =" https://25.18.168.1/api/detalle/"
    let idCliente=null;
    
    document.addEventListener('DOMContentLoaded', async () => {
        // Verificar si el cliente existe
        const parametrosURL = new URLSearchParams(window.location.search);
        idCliente = parseInt( parametrosURL.get('crs') );
    
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
        const tld = document.querySelector('#hhd');
    let x=0;
    let sub =0;
            const Curso = await obtenerestudiantes();
            
            Curso.forEach( est => {
                const {  nombre,nit,fecha,curso,precio } = est;
                const row = document.createElement('tr');
                sub = precio +sub;
                if(x==0)
                {
                    var fec = fecha;
                    tld.innerHTML += `<th> Nombre: ${nombre}</th> <th> Nit: ${nit}</th> <th> Fecha: ${fec.split('T')[0]}</th>`;
                    x=x+1;
                    
                    tld.innerHTML +=`<th> Curso </th> <th> Precio </th>  <th> Subtotal</th>`
                    row.innerHTML += `
                    <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                    <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${curso} </p>
                    </td>
                        <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                           
                            <p class="text-sm leading-10 text-gray-700"> Q${precio}  </p>
                        </td>
                        <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                            <p class="text-gray-700">Q${sub}</p>
                        </td>
                  
                    `;
                    listado.appendChild(row);
                }
                else
                {

                
                
    
                row.innerHTML += `
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${curso} </p>
                </td>
                    <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                       
                        <p class="text-sm leading-10 text-gray-700"> Q${precio}  </p>
                    </td>
                    <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                        <p class="text-gray-700">Q${sub}</p>
                    </td>
              
                `;
                listado.appendChild(row);
                }
               
            })
            const row = document.createElement('tr');
            row.innerHTML += `<td colspan="3"> Total = Q${sub}</td>`;
            listado.appendChild(row);
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