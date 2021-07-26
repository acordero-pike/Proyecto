const requestUrl = `https://localhost:5001/api/Cursos`
const CursoService = {
    getCursos() {
      return fetch(requestUrl, {
        method: "GET",
      }).then((response) => response.json());
    }
}

document.addEventListener("DOMContentLoaded", () => setCursos());

const setCursos = async () => {
    const tit = document.createElement("h1");
    tit.classList.add("encabezado");
    tit.setAttribute("id", "encabezado");
    tit.innerHTML=" Cursos En Línea";
    const cardListElement = document.querySelector("#lista-cursos");
 
    cardListElement.innerHTML = "";
    cardListElement.appendChild(tit);
    const dataCurso = await CursoService.getCursos();
    cursos = dataCurso;
    let x=0;
    let row = null; 
    cursos.forEach((curso, index) =>{ 
    if(x==0)
    {
    row =document.createElement('div');
    row.classList.add("row")
    }
    console.log(curso.idCurso);
    const card = document.createElement("div");
    card.classList.add("four" ,    "columns")
    card.innerHTML = `
    
    <div class="card">
    <div class="info-card">
    <h4> Nombre: ${curso.nombre}</h4>
    <h5>Descripcion: ${curso.descripcion}</h5>
    <h5  >Duracion: ${curso.duracion} hrs</h5>

    <p> Autor : ${curso.idInstructor} </p>
    <img src="../img/estrellas.png">
                        <p >  Costo: Q.${curso.costo} </p>
                  <a href="../pages/Login.html" class="u-full-width button-primary button input agregar-carrito" data-id="1">Agregar Al Carrito</a>
               </div>
            </div>
          
      `;
      row.appendChild(card);
    x=x+1;
    if (x<=      
        3)
    {
        cardListElement.appendChild(row);
        x=1;
    }
    });
  };
