let prearray = []


document.addEventListener('DOMContentLoaded', () => {
  const formulario = document.querySelector('#formulario');
formulario.addEventListener('submit', validar);
})

function consultarAPI() {
const us = document.querySelector("#user");
const con = document.querySelector("#cont");
 

let url = `https://localhost:5001/api/Usuarios/${us.value},${con.value}`;

fetch(url)
      .then(respuesta => respuesta.json()
      
      
      
      ).then(resultado => {
 
      const {status} = resultado;
      console.log(status)
      
   
        if(status === "400") {
           document.querySelector('#error').innerHTML='Acceso incorrecto Usuario o contraseña no Validos';
           setTimeout(() => {
            document.querySelector('#error').innerHTML=""
           },3000)
           return;
        } else if(status === "701")
        {
          document.querySelector('#error').innerHTML='Acceso incorrecto El usuario esta inactivo , contacte con el Administrador para solucionar su problema'
          setTimeout(() => {
           document.querySelector('#error').innerHTML=""
          },3000)
          return;
        }       
       
        else  {
           const { 0: id} = resultado;  
 
        prearray= [id] ;

        sincronizarStorage();

        let token="";
 prearray.forEach( ar =>  {  token =ar.token})
 var base64Url = token.split('.')[1];
 var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
 var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
     return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
 }).join(''));
const {Rol} = JSON.parse(jsonPayload)
if(Rol=="Administrador")
{
  window.location.href="../pages/Curso.html"
}else if(Rol=="Estudiante")
{
  window.location.href="../pages/index.html"
}
else{
  window.location.href="../pages/cursos.html"
}
         
         
        }
      } )
      .catch(error => {
        console.log(error)
        return;
      });

}
function validar()
{
  const us = document.querySelector("#user");
  const con = document.querySelector("#cont");

  if (us.value=='' || con.value=="")
  {
    document.querySelector('#error').innerHTML='Ambos Campos son necesarios ';
    
    setTimeout(() => {
      document.querySelector('#error').innerHTML=""
     },3000)
     return;
  }
  else{
    consultarAPI()
    return;
  }


}

function sincronizarStorage() {
  localStorage.setItem('Llave', JSON.stringify(prearray));
}
