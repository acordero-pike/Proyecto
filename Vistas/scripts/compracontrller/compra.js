 
let sub =0;
const fecha = new Date();
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
 

 
 prearray.forEach( ar =>  {    id= ar.id})
 
  
    const urlc =" https://localhost:5001/api/usuariosActvivos/"+id
    let articulosCarrito=[];
   
    document.addEventListener('DOMContentLoaded', async () => {
        articulosCarrito = JSON.parse( localStorage.getItem('carrito') ) || []  ;
  const btn = document.querySelector("#realizarpago");
  btn.addEventListener("click",save);
        carritoHTML();
        mostrar();
    });
   
 
  
 
    
    function carritoHTML(){
        const contenedorCarrito=document.querySelector('#lista-carrito tbody');
          //limpiar el HTMl
      
          //Recorre el carrito y genera el HTml
          articulosCarrito.forEach(curso=>{
              const { titulo, duracion,precio,id}=curso;
              const row=document.createElement('tr');
              
              row.innerHTML=`
              
             
              <td> ${titulo.split(':')[1]}</td>
              <td> ${duracion.split(':')[1]}</td>
              <td> ${precio.split(':')[1]}</td>
              <td> <a href="#" class="borrar-curso" data-id="${id}"> x </a> </td>
              
              `;
              //Agrega el HTML del carrito en el tbody
              contenedorCarrito.appendChild(row);
          });
        }
    const obtenerestudiantes = async () => {
        return fetch(urlc, {
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
  

            const Curso = await obtenerestudiantes();
            
            Curso.forEach( est => {
                
                const {  nombre,nit } = est;
                
               
           
                if(x==0)
                {
                    tld.innerHTML += `<th> Nombre: ${nombre}</th> <th> Nit: ${nit}</th> <th> Fecha: ${fecha.toLocaleDateString()}</th>`;

                    x=x+1;
                    
                    tld.innerHTML +=`<th> Curso </th> <th> Precio </th>  <th> Subtotal</th>`
                   
                }
               

                
                articulosCarrito.forEach(curso=>{
                    const row = document.createElement('tr');
                    const { titulo, duracion,precio,id}=curso;
    const pr = Number(precio.split(":")[1].split("Q.")[1]);
    sub = pr +sub;
                row.innerHTML += `
                <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                <p class="text-sm leading-5 font-medium text-gray-700 text-lg  font-bold"> ${titulo.split(":")[1]} </p>
                </td>
                    <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200">
                       
                        <p class="text-sm leading-10 text-gray-700"> Q${pr}  </p>
                    </td>
                    <td class="px-6 py-4 whitespace-no-wrap border-b border-gray-200 ">
                        <p class="text-gray-700">Q${sub}</p>
                    </td>
              
                `;
                listado.appendChild(row);
                })
               
            })
            const row = document.createElement('tr');
            row.innerHTML += `<td colspan="3"> Total = Q${sub}</td>`;
            listado.appendChild(row);
        }

        
    function catchError( error ,msj){

        console.log( error.status );
       
      
      }
function getcompra() {
    const f = fecha.getFullYear() + '-'+ fecha.getMonth() +'-'+fecha.getDay()
    const data ={
        idEstudiante : id,
         
        total :sub,
    }
return data


}
let compra=null;
function getFormData() {
    let newdata = [];  
    articulosCarrito.forEach(curso=>{
        const prr =
        {
          CodCurso:Number(curso.id.split(":")[1]),
             Precio : Number(curso.precio.split(":")[1].split("Q.")[1]),
            IdCompra:compra,

        }
        newdata =[...newdata,prr]
    })
    return newdata;
}

      async function save()
      {
        let compradata = getcompra();
       
      compra= await compraservice.guardarcompra(compradata)
      console.log(compra)


      let detalle = getFormData();
      detalle.forEach(de => {

      compraservice.guardardetalle(de)

      })

      console.log(detalle)
    
      }