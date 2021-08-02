const cardListElement = document.getElementById("Comentario");
const modalButton = document.getElementById("modalButton");
const submitButton = document.getElementById("submitButton");
const closeModalButton = document.getElementById("closeModalButton");
const form = document.getElementById("form");


let currentComentario = null;
let comentarios = [];


const setComentariosValuesToForm = (comentarioo) => {
  const { pregunta, leccion, respuesta, curso} =
    form.elements;
console.log(comentarioo);
pregunta.value = comentarioo.pregunta;
leccion.value = comentarioo.leccion;
respuesta.value = comentarioo.respuesta;
curso.value = comentarioo.curso;
};


const openModalEdit = (index) => {
  currentComentario = comentarios[index];
  console.log(currentComentario)
  setComentariosValuesToForm(currentComentario);
  modalButton.click();
};


const openModalAdd = () => {
  currentComentario = null;
  modalButton.click();
};


const deleteComentario = (index) => {
  ComentarioService.deleteComentarios(comentarios[index].idComentario)
    .then(() => setComentarios())
    .catch(console.error);
};


const insertComentarioIntoDom = (comm, index) => {
  console.log(comm.idComentario);
  const card = `
    <div class="card col-4 mx-1">
          <div class="card-body">
            <h5 class="card-title" hidden>Id Comentario: ${comm.idComentario}</h5>
            <h5 class="card-title">Pregunta:${comm.pregunta}</h5>
            <h5 class="card-title">Respuesta:${comm.respuesta}</h5>
            <h5 class="card-title" hidden>Leccion: ${comm.leccion}</h5>
            <h5 class="card-title" >Curso: ${comm.idCurso}</h5>



            
            <button onclick="location.href='../pages/Respuestacomentario.html'"class="btn btn-primary">Responder Comentario</button>
          </div>
        </div>
    `;
  cardListElement.innerHTML += card;
};


const setComentarios = async () => {
  const urlParams = new URLSearchParams(window.location.search);
const idCurso = urlParams.get('id');
  cardListElement.innerHTML = "";
  const dataComentario = await ComentarioService.getComentarios(idCurso);
  comentarios = dataComentario;
  comentarios.forEach((comentario, index) => insertComentarioIntoDom(comentario, index));
};


getFormData = () => {
  const urlParams = new URLSearchParams(window.location.search);
    const idCurso = urlParams.get('id');
  const { pregunta, leccion, respuesta,curso} =
    form.elements;
  
    console.log(form.elements);
  return {
    
    Pregunta: pregunta.value,
    Leccion: leccion.value,
    IdCurso: idCurso
  };
};

document.addEventListener("DOMContentLoaded", () => setComentarios());

closeModalButton.addEventListener("click", () => form.reset());


submitButton.addEventListener("click", () => {
  let formData = getFormData();
  if (currentComentario === null) {
    ComentarioService.guardarComentarios(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setComentarios());
  } else {
    formData = { ...formData, idComentario: currentComentario.idComentario };
    ComentarioService.updateComentarios(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setComentarios());
  }
});
