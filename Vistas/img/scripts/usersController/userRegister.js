import UserService from "../services/userService.js";
import LocalStorage from "../utils/LocalStorage.js";
import StaticAlert from "../utils/staticAlert.js";

(function () {
  const form = document.getElementById("form");
  form.addEventListener("submit", validateUser);

  function validateUser(e) {
    e.preventDefault();

    const nombre = document.getElementById("fname").value;
    const apellido = document.getElementById("lname").value;
    const correo = document.getElementById("email").value;
    const telefono = document.getElementById("mob").value;
    const contraseña = document.getElementById("pass").value;

    const user = {
      nombre,
      apellido,
      correo,
      telefono,
      contraseña,
    };

    if (!isFormValid(user)) {
      StaticAlert.show("Todos los campos son requeridos", form);
      return;
    }
    //const id = LocalStorage.get("userId");
    UserService.register(user)
      .then((response) => {
        alert(response);
      })
      .catch((error) => alert(error.message));
  }

  function isFormValid(obj) {
    return Object.values(obj).every((input) => input !== "");
  }
})();
