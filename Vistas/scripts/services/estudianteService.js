const requestUrl = `${URL}/estudiantes`
let token=null;

let prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  

const estudianteService = {
  getEstudiantes() {
    return fetch(requestUrl, {
      method: "GET",
    }).then(response => {
      
      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  }).catch( catchError )

  },
  deleteEstudiante(idEstudiante) {
    return fetch(requestUrl, {
      method: "DELETE",
      headers:myHeaders,
      body: JSON.stringify({idEstudiante: idEstudiante})
    }).then(response => {
      
      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  }).catch( catchError )

  },
  updatEstudiante(body) {
    return fetch(requestUrl, {
      method: "PUT",
      headers:myHeaders,
      body: JSON.stringify(body),
    }).then(response => {
      
      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  }).catch( catchError )

  },
  register(body) {
    return fetch(requestUrl, {
      method: "POST",
      headers,
      body: JSON.stringify(body),
    }).then(response => {
      
      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  }).catch( catchError )

  },
};

export const obtenerEstudiante = async idEstudiante => 
{
  try {
    const resultado = await fetch(`${requestUrl}/${idEstudiante}`);
    const instructor = await resultado.json();
    //console.log(instructor);
    return instructor;
  } catch (error) {
    console.log(error);
  }
}

export default estudianteService;


function catchError( error ,msj){

  console.log( error.status );
   
  if (msj==null && error.status==401)
  {
      msj="Algo Salio Mal... ,No tiene permitido el uso de este Recurso";
  }
  else if(msj==null)
  {
     msj="Algo Salio Mal...";
  }
//   
window.location.href=`error.html?id=${msj}`;

}