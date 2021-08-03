 prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})
let leccome=null;
  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
function getParameterByName(name) {
  name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
  var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
      results = regex.exec(location.search);
  return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
};
let idCurso = getParameterByName('id');

window.onload = () => {

  obtenerLecciones();

}

// obtenemos los elementos de htmls mediante un id
const video=document.getElementById("video");
const form = document.getElementById("form");
 const parametrosURL = new URLSearchParams(window.location.search);
   const idcurs = parseInt( parametrosURL.get('id') );

let currentLeccion = null;
let lecciones = [];



  


  async function obtenerLecciones(){


    const url = `https://25.18.168.1/api/ListaLecciones/${idCurso}`;

    await fetch(url,{
      method: "GET",
      headers:myHeaders,
    })
    .then(respuesta => respuesta.json())
    .then(resultado => {
        console.log(resultado);
        mostrarLecciones(resultado);
    })

}

function mostrarLecciones(lecciones) {
  const mostrar = document.querySelector('#cardList');
  lecciones.forEach(leccion => {
      const { idLeccion, titulo, descripcion, duracion,enlaceVideo } = leccion;
     console.log(idLeccion,titulo,descripcion,duracion,enlaceVideo)
      mostrar.innerHTML += `
          <div class="card" style="border-radius: 5px; background: -webkit-linear-gradient(left, #8c4a72 0%,#e44e52 100%);" id="leccion">
              <div class="card-body">
              <center>  <h5 class="card-title ">Titulo:${titulo}</h5>
              <center>  <h5 class="card-title" >Descripción: ${descripcion}</h5>
              <center> <button onclick="visualizarVideo ('${enlaceVideo}',${idLeccion});" class="btn" style="background-color: #33C3F0; color:white;">Ver</button>
               
                </div>
          </div>

                `;})}


                async function visualizarVideo(codigoVideo,idLeccion){

                  leccionEnProceso = idLeccion;
                  leccome=idLeccion;
                  setComentarios();
                  const visualizador = document.querySelector('#visualizador');
                  const contenedorVideo = document.querySelector('#video');
              
                  if(visualizador){
                      contenedorVideo.removeChild(visualizador);
                  }else{
                     
                  }
                   codigoVideo = getCodigoVideo('v',codigoVideo)
                  var video = document.createElement('iframe');
              
                  video.width = "98%";
                  video.height = "98%";
                  video.id="visualizador";
                  video.title="YouTube video player";
                  video.frameborder="0";
                  video.allowFullscreen="1";
                  video.allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture;";
                  video.src = `https://www.youtube.com/embed/${codigoVideo}?&autoplay=1&modestbranding=1&rel=0&showinfo=0&iv_load_policy=3&rel=0`;
              
                  contenedorVideo.appendChild(video);
              
                  
              
                      
              }           
              function getCodigoVideo(name,enlace) {
                name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(enlace);
                return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            };