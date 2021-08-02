import estudianteService, { obtenerEstudiante } from "../services/estudianteService.js";
import usuarioServicio from "../services/usuariosServicio.js";
import StaticAlert from "../utils/staticAlert.js";

(function(){
    const nombreI = document.getElementById('nombre');
    const apellidoI = document.getElementById('apellido');
    const telefonoI = document.getElementById('telefono');
    const correoI = document.getElementById('email');
    const contraseñaI = document.getElementById('pass');
    const nitI = document.getElementById('nit');
    const numTarjetaI = document.getElementById('numTarjeta')
    let idEstu;
    let idUsu;

    document.addEventListener('DOMContentLoaded', async() =>{
        const [{id}] = JSON.parse(localStorage.getItem("Llave"));
    console.log(id);
  const estudiante = await obtenerEstudiante(id);
  const btnActualizar = document.getElementById('actualizar');
  const btnDesactivar = document.getElementById('desactivar');

  btnActualizar.addEventListener('click', validateEstudiante);
  btnDesactivar.addEventListener('click', desactivarCuenta);
  console.info(estudiante);


  mostrarDatos(estudiante);

        

    });

    function mostrarDatos(estudiante){
        const [{idUsuario ,idEstudiante ,nombre, apellido, telefono, correo, contraseña, nit, numeroTarjeta}] = estudiante;
           console.info(estudiante);   
        nombreI.value = nombre;
        apellidoI.value = apellido;
        telefonoI.value = telefono;
        correoI.value = correo;
        contraseñaI.value = contraseña;
        nitI.value = nit;
        numTarjetaI.value = numeroTarjeta;
        idUsu = idUsuario;
        idEstu = idEstudiante;
        console.info(idUsu);
        console.info(idEstu);
        
    }

    function validateEstudiante(e){
      e.preventDefault();

      const estudiante = {
        idEstudianes: idEstu,
        nit: nitI.value,
        numTarjeta: numTarjetaI.value,
     }

     const usuario = {
        idUsuario: idUsu,
        nombre: nombreI.value,
        apellido: apellidoI.value,
        telefono: telefonoI.value,
        correo: correoI.value,
        contraseña: contraseñaI.value,
     }

      if (!isFormValid(estudiante) || !isFormValid(usuario)) {
        StaticAlert.show("Todos los campos son requeridos", form);
        return;
      }

      estudianteService.updatEstudiante(estudiante)
        .then((response) => {
          alert(response);
        })
        .catch((error) => alert(error.message));

        usuarioServicio.updateUsuario(usuario)
        .then((response) => {
          alert(response);
          window.location.href="../pages/index.html"

        })
        .catch((error) => alert(error.message));

    }

    function desactivarCuenta(e){
      e.preventDefault();
      usuarioServicio.deleteUsuario(idUsu)
      .then((response) => {
        alert(response);
        localStorage.removeItem('Llave');
        localStorage.removeItem('carrito');
        window.location.href="../pages/Home.html"
      })
      .catch((error) => alert(error.message));
    }

    function isFormValid(obj) {
      return Object.values(obj).every((input) => input !== "");
    }

})();
