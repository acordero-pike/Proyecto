const url = "https://localhost:5001/api/Leccion/"
 

prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();

myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json');  
const LeccionService = {
    getLecciones(curso) {
            return fetch(url+curso, {
        headers:myHeaders,
         method: "GET",
      }).then((response) => response.json());
    },
    deleteLecciones(IdLeccion) {
      return fetch(url, {
        method: "DELETE",
        headers,
        body: JSON.stringify({IdLeccion: IdLeccion})
      }).then((response) => response.json());
    },
    updateLecciones(body) {
      console.info(body);
      return fetch(url, {
        method: "PUT",
        headers,
        body: JSON.stringify(body),
      }).then((response) => response.json());
    },
    guardarLecciones(body) {
      return fetch(url, {
        method: "POST",
        headers,
        body: JSON.stringify(body),
      }).then((response) => response.json());
    },
  };
  
 