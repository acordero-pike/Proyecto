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
    return fetch(url+id, {
      method: "GET",
      headers:myHeaders,
    }).then(response => {
      if( !response.ok ){
    
        catchError( response );

    } else {
      

     return response.json();

    }

}).catch( catchError )
    
  }}
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