const cardListElement = document.getElementById("cardList");
document.addEventListener("DOMContentLoaded", () => setCursos());
const url="https://localhost:5001/api/miscursos/"
const insertCursoIntoDom = (curso, index) => {
 
    const card = `
      <div class="card col-4 mx-1">
            <div class="card-body" style="
      text-align: center;
  ">
              <h5 class="card-title">Nombre: ${curso.nombre}</h5>
              <h5 class="card-title"  hidden>Id Curso:${curso.idCurso}</h5>
              <h5 class="card-title">Descripcion: ${curso.descripcion}</h5>
               
              <h5 class="card-title">Instructor :${curso.idInstructor}</h5>
              <h5 class="card-title">Duracion: ${curso.Lecciones} hrs</h5>
              
                     <a href="VerListaLecciones.html?id=${curso.idCurso}" class="text-teal-600 hover:text-teal-900 mr-5"><button> Ver Curso </button> </a>
  
            </div>
          </div>
      `;
    cardListElement.innerHTML += card;
  };


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

