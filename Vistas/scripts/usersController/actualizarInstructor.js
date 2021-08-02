import instructorService, { obtenerInstructor } from "../services/instructorService.js";
import usuarioServicio from "../services/usuariosServicio.js";
import StaticAlert from "../utils/staticAlert.js";

(function(){
    const nombreI = document.getElementById("nombre");
    const apellidoI = document.getElementById('apellido');
    const telefonoI = document.getElementById('telefono');
    const correoI = document.getElementById('email');
    const contraseñaI = document.getElementById('pass');
    const estudiosI = document.getElementById('Estudios');
    const certificacionI = document.getElementById('Certificaciones');
    const experienciaLabI = document.getElementById('ExperienciaLab');
    const cuentaBancariaI = document.getElementById('numeroCuenta');
    let idInst;
    let idUsu;

    document.addEventListener('DOMContentLoaded', async() =>{
        const [{id}] = JSON.parse(localStorage.getItem("Llave"));
    console.log(id);
  const instructor = await obtenerInstructor(id);
  const form = document.getElementById('form');
  const btnActualizar = document.getElementById('enviarDatos');
  const btnDesactivar = document.getElementById('desactivarCuenta');
  btnActualizar.addEventListener('click', validateInstructor);
  btnDesactivar.addEventListener('click', desactivarCuenta);
  console.info(instructor);

  mostrarDatos(instructor);

        

    });

    function mostrarDatos(instructor){
        const [{idUsuario ,idInstructor ,nombre, apellido, telefono, correo, constraseña, estudios, certificacion, experienciaLab, cuentaBancaria}] = instructor;
        console.log(instructor);
        console.log(nombre);
        nombreI.value = nombre;
        apellidoI.value = apellido;
        telefonoI.value = telefono;
        correoI.value = correo;
        contraseñaI.value = constraseña;
        estudiosI.value = estudios;
        certificacionI.value = certificacion;
        experienciaLabI.value = experienciaLab;
        cuentaBancariaI.value = cuentaBancaria;
        idInst = idInstructor;
        idUsu = idUsuario;
        console.info(idInst);
  console.info(idUsu);
    }

    function validateInstructor(e){
      e.preventDefault();

      const instructor = {
        idInstructor: idInst ,
        estudios: estudiosI.value,
        certificacion: certificacionI.value,
        experienciaLab: experienciaLabI.value,
        cuentaBancaria: cuentaBancariaI.value,
     }

     const usuario = {
        idUsuario: idUsu,
        nombre: nombreI.value,
        apellido: apellidoI.value,
        telefono: telefonoI.value,
        correo: correoI.value,
        contraseña: contraseñaI.value,
     }

      if (!isFormValid(instructor) || !isFormValid(usuario)) {
        StaticAlert.show("Todos los campos son requeridos", form);
        return;
      }
      //const id = LocalStorage.get("userId");
      instructorService.updateInstructor(instructor)
        .then((response) => {
          alert(response);
        })
        .catch((error) => alert(error.message));

        usuarioServicio.updateUsuario(usuario)
        .then((response) => {
          alert(response);
          window.location.href="../pages/cursos.html"
        })
        .catch((error) => alert(error.message));

    }

    function desactivarCuenta(e){
      e.preventDefault();
      usuarioServicio.deleteUsuario(idUsu)
      .then((response) => {
        alert(response);
        localStorage.removeItem('Llave');
        window.location.href="../pages/Home.html"
      })
      .catch((error) => alert(error.message));
    }

    function isFormValid(obj) {
      return Object.values(obj).every((input) => input !== "");
    }

})();
