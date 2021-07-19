import UserService from "../services/userService.js";
import LocalStorage from "../utils/LocalStorage.js";
import { getUser } from "../services/getUserByID.js";


(() => {
  document.addEventListener("DOMContentLoaded", () => {
    const id = LocalStorage.get("userId");
    console.log(id);
    getUser(id);
  });
})();
