const url = "https://localhost:5001/api/Leccion/"
 
 
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
const LeccionService = {
  
 
  getLecciones(curso) {
    return fetch(url+curso, {
      method: "GET"
     
    }).then(response => {

      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  }).catch( catchError )



    
  },
  deleteLecciones(IdLeccion) {
    return fetch(url, {
      method: "DELETE",
      headers:myHeaders,
      body: JSON.stringify({IdLeccion: IdLeccion})
    }).then(response => {
 
      if( !response.ok ){
          const msj= "Este Curso ya tiene participantes o ya posee lecciones , no se puede eliminar";
        
          catchError( response,msj );
  
      } else {
  
       return response;
  
      }
  
  }).catch( catchError )

  },
  updateLecciones(body) {
    console.info(body);
    return fetch(url, {
      method: "PUT",
      headers:myHeaders,
      body: JSON.stringify(body)
    }).then(response => {

      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response;
  
      }
  
  })  

  },
  guardarLecciones(body) {
    return fetch(url, {
      method: "POST",
      headers:myHeaders ,
      body: JSON.stringify(body),
    }).then(response => {

      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response;
  
      }
  
  }) 

  },
};

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