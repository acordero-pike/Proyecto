// ----- elements

// obtenemos los elementos de htmls mediante un id
const cardListElement = document.getElementById("cardList");
const modalButton = document.getElementById("modalButton");
const submitButton = document.getElementById("submitButton");
const closeModalButton = document.getElementById("closeModalButton");
const form = document.getElementById("form");

// ----- vars

// declaramos algunas variables globales
let currentCurso = null;
let cursos = [];

// ------ functions

// seteamos los valores de un objeto empresa en los inputs del formulario
const setCusosValuesToForm = (curso) => {
  const { nombre, descripcion, costo, instructor, duracion } =
    form.elements;
console.log(curso);
  nombre.value = curso.nombre;
  descripcion.value = curso.descripcion;
  costo.value = curso.costo;
  idinstructor.value = curso. idinstructo;
  duracion.value = curso.duracion;
};

// abrimos el modal en modo de edición
const openModalEdit = (index) => {
  currentCurso = cursos[index];
  setCursosValuesToForm(currentCurso);
  modalButton.click();
};

// abrimos el modal en modo de guardado
const openModalAdd = () => {
  currentCurso = null;
  modalButton.click();
};

// llamamos al servicio de eliminacion
const deleteCurso = (index) => {
  CursoService.deleteCurso(cursos[index].idCurso)
    .then(() => setCursos())
    .catch(console.error);
};

// obtenemos el tiempo formateado como html con la hora del backend
/*const getTime = (horaInicio) => {
  return horaInicio.hours !== 0 && horaInicio.minutes !== 0
    ? `<p class="card-text"><b>Hora Inicio</b> ${
        horaInicio.hours
      }:${horaInicio.minutes.toString().padStart(2, 0)} </p>`
    : "";
};*/

// con los datos de la empresa creamos una linda tarjetita para mostrar su información
const insertCursoIntoDom = (curso, index) => {
  console.log(curso.idCurso);
  const card = `
    <div class="card col-4 mx-1">
          <div class="card-body">
            <h5 class="card-title">Nombre: ${curso.nombre}</h5>
            <h5 class="card-title">Id Curso:${curso.idCurso}</h5>
            <h5 class="card-title">Descripcion: ${curso.descripcion}</h5>
            <h5 class="card-title"> Costo: Q.${curso.costo}</h5>
            <h5 class="card-title">Instructor :${curso.idInstructor}</h5>
            <h5 class="card-title">Duracion: ${curso.duracion} hrs</h5>
            
            <button onclick="openModalEdit(${index})" class="btn btn-primary"> Editar </button>
            <button onclick="deleteEmpresa(${index})" class="btn btn-danger"> Eliminar </button>
          </div>
        </div>
    `;
  cardListElement.innerHTML += card;
};

// limpiamos las empresas renderizadas,
// hacemos nuevo request con las empresas y las renderizamos
const setCursos = async () => {
  cardListElement.innerHTML = "";
  const dataCurso = await CursoService.getCursos();
  cursos = dataCurso;
  cursos.forEach((curso, index) => insertCursoIntoDom(curso, index));
};

// obtenemos los valores del input y los formateamos a json
getFormData = () => {
  const { nombre, descripcion, costo, idinstructor, duracion } =
    form.elements;
  
  return {
    nombre: nombre.value,
    descripcion: descripcion.value,
    costo: costo.value,
    idinstructor: idinstructor.value,
    duracion: duracion.value,
  };
};

// ----- events

// cuando el dom cargue seteamos las empresas
document.addEventListener("DOMContentLoaded", () => setCursos());

// cuando el boton de cerrar modal sea clicado reseteamos el form
closeModalButton.addEventListener("click", () => form.reset());

// sino hay un usuario seleccionado agregamos uno con el servicio de guardado
// si hay un usuario seteado lo modificamos con el servicio de actualizacion
// recargamos los elementos renderizados
submitButton.addEventListener("click", () => {
  let formData = getFormData();
  if (currentCurso === null) {
    CursoService.saveCurso(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setCursos());
  } else {
    formData = { ...formData, idCurso: currentCurso.idCurso };
    CursoService.updateCurso(formData)
      .then(() => closeModalButton.click())
      .catch(console.error)
      .finally(() => setCursos());
  }
});
