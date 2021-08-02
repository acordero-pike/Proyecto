const url = "https://localhost:5001/api/compra"
const URLD = "https://localhost:5001/api/CompraDetalle"
 
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
const compraservice = {
   
  guardarcompra(body) {
    console.info(body);
    return fetch(url, {
      method: "POST",
      headers:myHeaders,
      body: JSON.stringify(body)
    }).then(response => {

      if( !response.ok ){
  
          catchError( response );
  
      } else {
  
       return response.json();
  
      }
  
  })  

  },
  guardardetalle(body) {
    return fetch(URLD, {
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
   

}