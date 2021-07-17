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
        } else  {
           const { 0: id} = resultado;  
 
        prearray= [id] ;
        sincronizarStorage();
          window.location.href="../pr/index.html"
         
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
