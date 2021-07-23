const cardListElement = document.getElementById("cardList");
const modalButton = document.getElementById("modalButton");
const submitButton = document.getElementById("submitButton");
const closeModalButton = document.getElementById("closeModalButton");
const form = document.getElementById("form");


let currentLeccion = null;
let lecciones = [];


const setCusosValuesToForm = (leccionn) => {
  const { Titulo, Descripcion, Duracion, EnlaceVideo, IdCurso } =
    form.elements;
console.log(leccionn);
Titulo.value = leccionn.Titulo;
Descripcion.value = leccionn.Descripcion;
Duracion.value = leccionn.Duracion;
EnlaceVideo.value = leccionn. EnlaceVideo;
IdCurso.value = leccionn.IdCurso;
};


const openModalEdit = (index) => {
  currentLeccion = lecciones[index];
  setCursosValuesToForm(currentLeccion);
  modalButton.click();
};


const openModalAdd = () => {
  currentLeccion = null;
  modalButton.click();
};


const deleteLeccion = (index) => {
  LeccionService.deleteLeccion(lecciones[index].IdLeccion)
    .then(() => setLecciones())
    .catch(console.error);
};


const insertLeccionIntoDom = (lecc, index) => {
  console.log(lecc.IdLeccion);
  const card = `
    <div class="card col-4 mx-1">
          <div class="card-body">
            <h5 class="card-title">Id Leccion: ${lecc.IdLeccion}</h5>
            <h5 class="card-title">Titulo:${lecc.Titulo}</h5>
            <h5 class="card-title">Descripcion: ${lecc.Descripcion}</h5>
            <h5 class="card-title"> Duración:${lecc.Duracion}</h5>
            <h5 class="card-title">Enlace:${lecc.EnlaceVideo}</h5>
            <h5 class="card-title">Id Curso: ${lecc.IdCurso} hrs</h5>
            
            <button onclick="openModalEdit(${index})" class="btn btn-primary"> Editar </button>
            <button onclick="deleteEmpresa(${index})" class="btn btn-danger"> Eliminar </button>
          </div>
        </div>
    `;
  cardListElement.innerHTML += card;
};


const setLecciones = async () => {
  cardListElement.innerHTML = "";
  const dataLeccion = await LeccionServiceService.setLecciones();
  lecciones = dataLeccion;
  lecciones.forEach((leccion, index) => insertLeccionIntoDom(leccion, index));
};


getFormData = () => {
  const { Titulo, Descripcion, Duracion, EnlaceVideo, IdCurso } =
    form.elements;
  
  return {
    Titulo: Titulo.value,
    Descripcion: Descripcion.value,
    Duracion: Duracion.value,
    EnlaceVideo: EnlaceVideo.value,
    IdCurso: IdCurso.value,
  };
};

document.addEventListener("DOMContentLoaded", () => setLecciones());

closeModalButton.addEventListener("click", () => form.reset());


submitButton.addEventListener("click", () => {
  let formData = getFormData();
  if (currentLeccion === null) {
    LeccionService.saveLeccion(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setLecciones());
  } else {
    formData = { ...formData, IdLeccion: currentLeccion.IdLeccion };
    LeccionService.updateLeccion(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setLecciones());
  }
});
