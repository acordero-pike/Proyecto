let prearray = [];
let nombre ="";


document.addEventListener('DOMContentLoaded', () => {
    prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
   
    

    if (prearray.length >0)
{

   prearray.forEach( ar =>  {  nombre =ar.nombre})

    document.querySelector("#nav-placeholder").innerHTML=`<nav class="navbar navbar-expand navbar-dark bg-dark" aria-label="Second navbar example">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Lerning2teach</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02" aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
  
        <div class="collapse navbar-collapse" id="navbarsExample02">
          <ul class="navbar-nav me-auto">
         <li class="nav-item">
              <a class="nav-link active" aria-current="page" href="../pages/index.html"  >Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../pages/cursos.html">Cursos</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">acerca de </a>
            </li>
          </ul>
          <div class="two columns u-pull-right">
          <ul>
              <li class="submenu">
                      <img src="img/cart.png" id="img-carrito">
                      <div id="carrito">
                              
                      <table id="lista-carrito" class="u-full-width">
                      <thead>
                      <tr>
                                         
                      <th>Nombre</th>
                     
                      <th>Duración</th>
                      <th>Precio</th>
                      <th></th>
                      <th></th>
                  </tr>
                  <th></th>
              </thead>
              <tbody>
              
              </tbody>
          </table>

                              <a href="#" id="vaciar-carrito" class="button u-full-width">Vaciar Carrito</a>
                      </div>
              </li>
          </ul>
      </div>
          <div class="navbar-nav" id="logg">
        <a class="nav-link"  style="color:white ;" href="../pages/updateUser.html">${nombre}</a>
    <a class="nav-link"  style="color:white ;" id="logoff" >LogOff</a>
        </div>
      </div>
      </div>
    </nav>
  `;
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
    document.querySelector("#nav-placeholder").innerHTML=`   <nav class="navbar navbar-expand navbar-dark bg-dark" aria-label="Second navbar example">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Lerning2teach</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02" aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
  
        <div class="collapse navbar-collapse" id="navbarsExample02">
          <ul class="navbar-nav me-auto">
          <li class="nav-item">
              <a class="nav-link active" aria-current="page" href="../pages/Inicio.html"  >Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../pages/Home.html">Cursos</a>
          
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">acerca de </a>
            </li>
          </ul>
          <div class="navbar-nav" id="logg">
       <a class="nav-link"  style="color:white ;" href="../pages/Login.html">Login </a>
    <a class="nav-link"  style="color:white ;"   href="../pages/userRegister.html">singup </a>
        </div>
      </div>
      </div>
    </nav>
    
    `;
}








})
