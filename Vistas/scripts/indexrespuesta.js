const cardListElement = document.getElementById("cardList");
const modalButton = document.getElementById("modalButton");
const submitButton = document.getElementById("submitButton");
const closeModalButton = document.getElementById("closeModalButton");
const form = document.getElementById("form");


let currentComentario = null;
let comentarios = [];


const setComentariosValuesToForm = (comentarioo) => {
  const { pregunta, leccion, respuesta} =
    form.elements;
console.log(comentarioo);
pregunta.value = comentarioo.pregunta;
leccion.value = comentarioo.leccion;
respuesta.value = comentarioo.respuesta;
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
            <h5 class="card-title"hidden>Id Comentario: ${comm.idComentario}</h5>
            <h5 class="card-title">Pregunta:${comm.pregunta}</h5>
            <h5 class="card-title">Leccion: ${comm.leccion}</h5>
            <h5 class="card-title">Respuesta: ${comm.respuesta}</h5>
            
            <button onclick="openModalEdit(${index})" class="btn btn-primary"> Agregar Respuesta </button>
          </div>
        </div>
    `;
  cardListElement.innerHTML += card;
};


const setComentarios = async () => {
  cardListElement.innerHTML = "";
  const dataComentario = await ComentarioService.getComentarios();
  comentarios = dataComentario;
  comentarios.forEach((comentario, index) => insertComentarioIntoDom(comentario, index));
};


getFormData = () => {
  const { pregunta, leccion, respuesta} =
    form.elements;
  
    console.log(form.elements);
  return {
    Pregunta: pregunta.value,
    Leccion: leccion.value,
    Respuesta: respuesta.value,
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
