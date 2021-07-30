import estudianteService from "../services/estudianteService.js";
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
      const numeroTarjeta = document.getElementById("numeroTarjeta").value;
      const nit = document.getElementById("nit").value;
  
      const estudiante ={
        nit,
        numeroTarjeta,
  usuarioNavigation: {
    nombre,
    apellido,
    telefono,
    correo,
    contraseña,
  }
      };
  
      if (!isFormValid(estudiante)) {
        StaticAlert.show("Todos los campos son requeridos", form);
        return;
      }
  
      console.log(estudiante);
      estudianteService.register(estudiante)
        .then((response) => {
          alert("Estudiante registrado");
        })
        .catch((error) => alert(error.message));
    }
  
    function isFormValid(obj) {
      return Object.values(obj).every((input) => input !== "");
    }
  })();
  