const cardListElement = document.getElementById("cardList");
document.addEventListener("DOMContentLoaded", () => setCursos());
const url="https://localhost:5001/api/miscursos/"
const insertCursoIntoDom = (curso, index) => {
 console.log(curso)
    const card = `
      <div class="card col-4 mx-1">
            <div class="card-body" style="
      text-align: center;
  ">
              <h5 class="card-title">Nombre: ${curso.nombre}</h5>
              <h5 class="card-title"  hidden>Id Curso:${curso.idCurso}</h5>
              <h5 class="card-title">Descripcion: ${curso.descripcion}</h5>
               
              <h5 class="card-title">Instructor :${curso.idInstructor}</h5>
              <h5 class="card-title">Duracion: ${curso.duracion} hrs</h5>
              <h5 class="card-title">Lecciones: ${curso.lecciones} </h5>
              
                     <a href="VerListaLecciones.html?id=${curso.idCurso}" class="text-teal-600 hover:text-teal-900 mr-5"><button> Ver Curso </button> </a>
  
            </div>
          </div>
      `;
    cardListElement.innerHTML += card;
  };

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
  const setCursos = async () => {
    cardListElement.innerHTML = "";
    const dataCurso = await CursoService.getCursos();
    cursos = dataCurso;
    if(cursos.length<1)
    {
      cardListElement.innerHTML='No ha ingresao ningun curso , Igrese uno para listar'
    }
    cursos.forEach((curso, index) => insertCursoIntoDom(curso, index));
  };

  let articulosCarrito=[];
   
  document.addEventListener('DOMContentLoaded', async () => {
      articulosCarrito = JSON.parse( localStorage.getItem('carrito') ) || []  ;

      carritoHTML();
      
  });
 