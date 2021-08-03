const requestUrl = `https://25.18.168.1/api/Cursos`
let mensaje="Agregar Curso";

window.onload = () => {
  const search = document.querySelector("#buscador");
  const btns = document.querySelector("#submit-buscador");
 const listaCursos =document.querySelector('#lista-cursos');
 const pago = document.querySelector("#pago");
 //Débora Chacach
//variables
const carrito=document.querySelector('#carrito');
if (articulosCarrito.length>0)
{
   
  pago.hidden  =false;
}else{
   
  pago.hidden  =true;
}

 
const vaciarCarritoBtn=document.querySelector('#vaciar-carrito');

 //Eliminar cursos del carrito
 carrito.addEventListener('click', eliminarCurso);
   
//muestra los cursos de localStorage

 //vaciar carrito
 vaciarCarritoBtn.addEventListener('click',()=>{
     articulosCarrito=[]; //resetea el arreglo
     eliminarlocal();
     limpiarHTML();//eliminar todo html

 })
 listaCursos.addEventListener('click', agregarCurso);
  
  btns.addEventListener('click', () => {
    
    name= search.value;
    console.log(name);
    setCursos();
    
  }
  )
};

let name=null;
const CursoService = {
  getCursos() {
    return fetch(requestUrl, {
      method: "GET",
       
    }).then(response => {
      if( !response.ok ){
    
        catchError( response );

    } else {
      

     return response.json();

    }

}).catch( catchError )
    }
}
 
 
  
  
document.addEventListener("DOMContentLoaded", () => setCursos());
document.addEventListener('DOMContentLoaded',() =>{
  articulosCarrito=JSON.parse(localStorage.getItem('carrito'))||[];
  carritoHTML();

})

const setCursos = async () => {
  const tit = document.createElement("h1");
  tit.classList.add("encabezado");
  tit.setAttribute("id", "encabezado");
  tit.innerHTML=" Cursos En Línea";
  const cardListElement = document.querySelector("#lista-cursos");

  cardListElement.innerHTML = "";
  cardListElement.appendChild(tit);
  const dataCurso = await CursoService.getCursos();
  cursos = dataCurso;
  let x=0;
  let row = null; 
  if(name==null)
  {
  
    cursos.forEach((curso, index) =>{ 
    if(x==0)
    {
    row =document.createElement('div');
    row.classList.add("row")
    }
    
    const card = document.createElement("div");
    card.classList.add("four" ,    "columns")
    card.innerHTML = `
    
    <div class="card">
    <div class="info-card">
    <h6 id="ID"hidden>Id: ${curso.idCurso} </h6>
    <h4 id="titulo"> Nombre: ${curso.nombre}</h4>
    <h5 id="desc">Descripcion: ${curso.descripcion}</h5>
    <h3 id="duracion" >Duracion: ${curso.duracion} hrs</h3>

    <p id="autor"> Autor : ${curso.idInstructor} </p>
    <img src="../img/estrellas.png">
                        <h7 >  Costo: Q.${curso.costo} </h7>
                  <a href="#" class="u-full-width button-primary button input agregar-carrito"  data-id="1">${mensaje}</a>
               </div>
            </div>
          
      `;
      const boton=document.q
      row.appendChild(card);
    x=x+1;
     
    if (x>0)
    {
        cardListElement.appendChild(row);
       if(x==3)
       {
        x=0;
       }
    }
    });
  }
  else{
    cursos.forEach((curso, index) =>{ 
      if(x==0)
      {
      row =  document.createElement('div');
      row.classList.add("row")
      }
       
      const card = document.createElement("div");
      card.classList.add("four" ,    "columns")
     
      const nas= curso.nombre.toLowerCase();
      if(nas.search(name.toLowerCase()) != -1)
    {
      card.innerHTML = `
      
      <div class="card">
      <div class="info-card">
      <h6 id="ID" hidden>Id: ${curso.idCurso} </h6>
      <h4 id="titulo"> Nombre: ${curso.nombre}</h4>
      <h5 id="desc">Descripcion: ${curso.descripcion}</h5>
      <h3 id="duracion" >Duracion: ${curso.duracion} hrs</h3>
  
      <p id="autor"> Autor : ${curso.idInstructor} </p>
      <img src="../img/estrellas.png">
                          <h7 id="precio" >  Costo: Q.${curso.costo} </h7>
                    <a href="#" class="u-full-width button-primary button input agregar-carrito" data-id="1">Agregar Al Carrito</a>
                 </div>
              </div>
            
        `;
        row.appendChild(card);
        console.log("entro")
        x=x+1;
    }else
    {

    }
       
     
    if (x>0)
    {
        cardListElement.appendChild(row);
       if(x==3)
       {
        x=0;
       }
    }
      });
     console.log("x es "+x)
if(x==0)
{
  const card = document.createElement("div");
  
  card.innerHTML = ` <div class="card">
  <div class="info-card" >
  <h4 style="
  text-align: center;
">  Sin Resultados </h4>
  </div>
  </div>`
  row.appendChild(card);
  cardListElement.appendChild(row);
}
  }
  };



//const listaCursos=document.querySelector('#lista-cursos');
let articulosCarrito=[];
document.addEventListener('DOMContentLoaded', () => {
  articulosCarrito = JSON.parse( localStorage.getItem('carrito') ) || []  ;
  
  carritoHTML();
});



//Funciones
function agregarCurso(e){

 
    e.preventDefault();
    if(e.target.classList.contains('agregar-carrito')){
    // const variable=e.target.classList;
     //variable.textContent='texto';
      const crusoSeleccionado=e.target.parentElement.parentElement;
      
      mensaje=1;
      leerDatosCurso(crusoSeleccionado);
      if (articulosCarrito.length>0)
      {
        console.log(1)
        pago.hidden  =false;
      }else{
        console.log(2)
        pago.hidden  =true;
      }

    }
    
}
//elimina un curso del carrito
function eliminarCurso(e){
 
    if(e.target.classList.contains('borrar-curso')){
        const cursoId=e.target.getAttribute('data-id');
        //elimina del arreglo de articulos del carrito
        articulosCarrito=articulosCarrito.filter(curso=>curso.id !== cursoId);
        sincronizarStorage();
        carritoHTML(); //iterar sobre el carrito y muestra html
        if (articulosCarrito.length>0)
        {
          console.log(1)
          pago.hidden  =false;
        }else{
          console.log(2)
          pago.hidden  =true;
        }
    }

}






//leer contenido al que se le da click
function leerDatosCurso(curso){

  console.log(curso);
  
    //crear un objet con el contenido del curso
    const infoCurso={
        titulo:curso.querySelector('h4').textContent,
        desc:curso.querySelector('h5').textContent,
        duracion:curso.querySelector('h3').textContent,

        precio:curso.querySelector('h7').textContent,
        id: curso.querySelector('h6').textContent,
        cantidad:1
    }
    
    
//revisar si el elemento ya existe en el carrito
const existe=articulosCarrito.some(curso=> curso.id=== infoCurso.id);
if(existe){
  alert('El curso ya se encuentra en el carrito');

} else{
    //agregar curso al carrito
  
    articulosCarrito=[...articulosCarrito, infoCurso];
    console.log(articulosCarrito);
    sincronizarStorage();
    carritoHTML();
    

}
}

  
  



//muestra el carrito de compras
function carritoHTML(){
  const contenedorCarrito=document.querySelector('#lista-carrito tbody');
    //limpiar el HTMl
    limpiarHTML();
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
          //Agregar el carrito de compras al storage
   
    });
    sincronizarStorage();


}
function sincronizarStorage(){
  localStorage.setItem('carrito',JSON.stringify(articulosCarrito));
}


function limpiarHTML(){
    //contenedorCarrito.innerHTML='';
    const contenedorCarrito=document.querySelector('#lista-carrito tbody');
    while(contenedorCarrito.firstChild){
        contenedorCarrito.removeChild(contenedorCarrito.firstChild)
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


function sincronizarStorage() {
  localStorage.setItem('carrito', JSON.stringify(articulosCarrito));
}



   function eliminarlocal() {
  localStorage.removeItem('carrito');
 
}