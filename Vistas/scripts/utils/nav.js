let prearray = [];
let nombre ="";


document.addEventListener('DOMContentLoaded', () => {
    prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
   
    

    if (prearray.length >0)
{

   prearray.forEach( ar =>  {  nombre =ar.nombre})

    document.querySelector("#logg").innerHTML=` <a class="nav-link"  style="color:white ;" href="../pages/updateUser.html">${nombre}</a>
    <a class="nav-link"  style="color:white ;" id="logoff" >LogOff</a>`;
    const logoff = document.querySelector("#logoff") ;
    logoff.addEventListener('click', () => {

        const conf = confirm("Desea Salir de su Cuenta?");
        if (conf)
        {
    localStorage.removeItem('Llave');
    location.reload();
        }
        else{
    
        }
    
    })



}else{
    document.querySelector("#logg").innerHTML=` <a class="nav-link"  style="color:white ;" href="../pages/Login.html">Login </a>
    <a class="nav-link"  style="color:white ;"   href="../pages/userRegister.html">singup </a>`;
}








})



