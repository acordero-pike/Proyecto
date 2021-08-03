const ccr = document.getElementById("Comentario");
const modalButton = document.getElementById("modalButton");
const csc = document.querySelector('#submitButton');
const closeModalButton = document.getElementById("closeModalButton");
const formc = document.getElementById("formc");
const agg = document.querySelector("#agg")

let currentComentario = null;
let comentarios = [];


const setComentariosValuesToForm = (comentarioo) => {
  const { pregunta, leccion, respuesta, curso} =
    formc.elements;
console.log(comentarioo);
pregunta.value = comentarioo.pregunta;
leccion.value = leccome;
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
  let {leccion} =
    formc.elements;
    leccion.value=leccome
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
    <div class="card col-4 mx-1" style="
    border-radius: 5px;
">
          <div class="card-body">
            <h5 class="card-title" hidden>Id Comentario: ${comm.idComentario}</h5>
            <h5 class="card-title">Pregunta:${comm.pregunta}</h5>
            <h5 class="card-title">Respuesta:${comm.respuesta}</h5>
            <h5 class="card-title" hidden>Leccion: ${comm.leccion}</h5>
            <button onclick="location.href='../pages/Respuestacomentario.html?id=${comm.leccion}'"class="btn btn-primary">Responder Comentario</button>


          </div>
        </div>
    `;
  ccr.innerHTML += card;
};


const setComentarios = async () => {
 
 if (leccome!==null)
 {
  agg.disabled=false;

 } 
  ccr.innerHTML = "";
  const dataComentario = await ComentarioService.getComentarios(leccome);
  comentarios = dataComentario;
  comentarios.forEach((comentario, index) => insertComentarioIntoDom(comentario, index));
};


getFormData = () => {
   
     
  const { pregunta, leccion, respuesta} =
    formc.elements;
  
    console.log(formc.elements);
  return {
    
    Pregunta: pregunta.value,
    Leccion: leccome,
    
  };
};

document.addEventListener("DOMContentLoaded", () => setComentarios());

closeModalButton.addEventListener("click", () => formc.reset());

document.addEventListener("DOMContentLoaded", () =>  {

  agg.disabled =true

});

csc.addEventListener("click", () => {
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

 
 