
 
    const urlc =" https://localhost:5001/api/detalle/"
    let idCliente=null;
    
    document.addEventListener('DOMContentLoaded', async () => {
        // Verificar si el cliente existe
        const parametrosURL = new URLSearchParams(window.location.search);
        idCliente = parseInt( parametrosURL.get('crs') );
    
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