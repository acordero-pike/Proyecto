const requestUrl = `https://localhost:5001/api/Cursos`

  
window.onload = () => {
  const search = document.querySelector("#buscador");
  const btns = document.querySelector("#submit-buscador");
  btns.addEventListener('click', () => {
    
    name= search.value;
    console.log(name);
    setCursos();
    
  }
  )
};

let name=null;
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
  if(name==null)
  {
  
    cursos.forEach((curso, index) =>{ 
    if(x==0)
    {
    row =document.createElement('div');
    row.classList.add("row")
    }
    
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
                  <a href="#" class="u-full-width button-primary button input agregar-carrito" data-id="1">Agregar Al Carrito</a>
               </div>
            </div>
          
      `;
      row.appendChild(card);
    x=x+1;
     
    if (x>0)
    {
        cardListElement.appendChild(row);
       if(x==3)
       {
        x=0;
       }
    }
    });
  }
  else{
    cursos.forEach((curso, index) =>{ 
      if(x==0)
      {
      row =  document.createElement('div');
      row.classList.add("row")
      }
       
      const card = document.createElement("div");
      card.classList.add("four" ,    "columns")
     
    if(curso.nombre.search(name) != -1)
    {
      card.innerHTML = `
      
      <div class="card">
      <div class="info-card">
      <h4> Nombre: ${curso.nombre}</h4>
      <h5>Descripcion: ${curso.descripcion}</h5>
      <h5  >Duracion: ${curso.duracion} hrs</h5>
  
      <p> Autor : ${curso.idInstructor} </p>
      <img src="../img/estrellas.png">
                          <p >  Costo: Q.${curso.costo} </p>
                    <a href="#" class="u-full-width button-primary button input agregar-carrito" data-id="1">Agregar Al Carrito</a>
                 </div>
              </div>
            
        `;
        row.appendChild(card);
        console.log("entro")
        x=x+1;
    }else
    {

    }
       
     
    if (x>0)
    {
        cardListElement.appendChild(row);
       if(x==3)
       {
        x=0;
       }
    }
      });
     console.log("x es "+x)
if(x==0)
{
  const card = document.createElement("div");
  
  card.innerHTML = ` <div class="card">
  <div class="info-card" >
  <h4 style="
  text-align: center;
">  Sin Resultados </h4>
  </div>
  </div>`
  row.appendChild(card);
  cardListElement.appendChild(row);
}
  }
  };


 