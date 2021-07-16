

(function(){
const form = document.getElementById('form')
form.addEventListener('submit', validateUser);

    function validateUser(e){
        e.preventDefault();

        const name = document.getElementById('fname').value;
        const lastname = document.getElementById('lname').value;
        const email = document.getElementById('email').value;
        const phone = document.getElementById('mob').value;
        const pass = document.getElementById('pass').value;

        const user = {
            name, 
            lastname,
            email,
            phone,
            pass
        }

        if(validateForm(user)){
            console.log("Todos los campos son requeridos")
            return;
        }
        console.log("Validación correcta");
    }


    function validateForm(obj){
        return !Object.values(obj).every( input => input !== '');
    }

})();




