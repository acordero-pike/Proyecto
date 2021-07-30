prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
let id = null;
 prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
   
    
 prearray.forEach( ar =>  {  id =ar.id})
const CursoService = {
  getCursos() {
    return fetch(URL+'/'+id, {
      method: "GET",
      headers:myHeaders,
    }).then(response => {
      if( !response.ok ){
    
        catchError( response );

    } else {

     return response.json();

    }

}).catch( catchError )
    




    
  },
  deleteCurso(idCurso) {
    return fetch(URL, {
      method: "DELETE",
      headers:myHeaders,
      body: JSON.stringify({idCurso: idCurso})
    }).then(response => {
 
      if( !response.ok ){
          const msj= "Este Curso ya tiene participantes o ya posee lecciones , no se puede eliminar";
        
          catchError( response,msj );
  
      } else {
  
       return response;
  
      }
  
  }).catch( catchError )

  },
  updateCurso(body) {
    console.info(body);
    return fetch(URL, {
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
  saveCurso(body) {
    return fetch(URL, {
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