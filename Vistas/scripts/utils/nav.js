let prearray = [];
let nombre ="";
 
 
 



document.addEventListener('DOMContentLoaded', () => {
    prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
   
    
    

    if (prearray.length >0)
{

  prearray.forEach( ar =>  {  nombre =ar.nombre, token =ar.token })
 
  
  
  var base64Url = token.split('.')[1];
  var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));
const {Rol} = JSON.parse(jsonPayload)
console.log(Rol);

if (Rol=="Instructor")
{

    document.querySelector("#nav-placeholder").innerHTML=`<nav class="navbar navbar-expand navbar-dark bg-dark" aria-label="Second navbar example">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Lerning2teach</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02" aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
  
        <div class="collapse navbar-collapse" id="navbarsExample02">
          <ul class="navbar-nav me-auto">
         <li class="nav-item">
              <a class="nav-link active" aria-current="page" href="../pages/EstadisticasInstructor.html"  >Estadisticas</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../pages/cursos.html">Cursos</a>
            </li>
            
          </ul>
          <div class="navbar-nav" id="logg">
        <a class="nav-link"  style="color:white ;" href="../pages/updateUser.html">${nombre}</a>
    <a class="nav-link"  style="color:white ;" id="logoff" >LogOff</a>
        </div>
      </div>
      </div>
    </nav>
  `;
   
  }
  else if(Rol=="Estudiante")
  {
   
    document.querySelector("#nav-placeholder").innerHTML=`<nav class="navbar navbar-expand navbar-dark bg-dark" aria-label="Second navbar example">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Lerning2teach</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02" aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExample02">
        <ul class="navbar-nav me-auto">
       <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="../pages/index.html"  >Inicio</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../pages/miscursos.html">Mis Cursos</a>
          </li>
          <li class="nav-item">
          <a class="nav-link" href="../pages/Compras.html">Mis Facturas</a>
        </li>
          
        </ul>
        <div class="navbar-nav" id="logg">
      <a class="nav-link"  style="color:white ;" href="../pages/updateUser.html">${nombre}</a>
  <a class="nav-link"  style="color:white ;" id="logoff" >LogOff</a>
      </div>
    </div>
    </div>
  </nav>
`;
  }
  else
  {
    document.querySelector("#nav-placeholder").innerHTML=`<nav class="navbar navbar-expand navbar-dark bg-dark" aria-label="Second navbar example">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Lerning2teach</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample02" aria-controls="navbarsExample02" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExample02">
        <ul class="navbar-nav me-auto">
       <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#"  >Usuarios</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../pages/Usuarios.html">Estudiantes</a>
          </li>
          <li class="nav-item">
          <a class="nav-link" href="../pages/Curso.html">Cursos</a>
        </li>
        
          
        </ul>
        <div class="navbar-nav" id="logg">
      <a class="nav-link"  style="color:white ;" href="../pages/updateUser.html">${nombre}</a>
  <a class="nav-link"  style="color:white ;" id="logoff" >LogOff</a>
      </div>
    </div>
    </div>
  </nav>
`;
  }  
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
