const url = "https://25.18.168.1/api/compra"
const URLD = "https://25.18.168.1/api/CompraDetalle"
 
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