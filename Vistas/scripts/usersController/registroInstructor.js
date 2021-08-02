import instructorService from "../services/instructorService.js";
import StaticAlert from "../utils/staticAlert.js";

(function () {
    const form = document.getElementById("form");
    form.addEventListener("submit", validateUser);
  
    function validateUser(e) {
      e.preventDefault();
  
      const nombre = document.getElementById("nombre").value;
      const apellido = document.getElementById("apellido").value;
      const correo = document.getElementById("email").value;
      const telefono = document.getElementById("telefono").value;
      const contraseña = document.getElementById("pass").value;
      const cuentaBancaria = document.getElementById("numeroCuenta").value;
      const estudios = document.getElementById("estudios").value;
      const certificacion = document.getElementById("certificaciones").value;
      const experienciaLab = document.getElementById("experienciaLab").value;
  
      const instructor ={
        estudios,
        certificacion,
        experienciaLab,
        cuentaBancaria,
        usuarioNavigation: {
          nombre,
          apellido,
          telefono,
          correo,
          contraseña,
  }
      };
  
      if (!isFormValid(instructor)) {
        StaticAlert.show("Todos los campos son requeridos", form);
        return;
      }
  
      console.log(instructor);
      instructorService.register(instructor)
        .then((response) => {
          alert("Instructor registrado");
          window.location.href="../pages/cursos.html"

        })
        .catch((error) => alert(error.message));
    }
  
    function isFormValid(obj) {
      return Object.values(obj).every((input) => input !== "");
    }
  })();
  