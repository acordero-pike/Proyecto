const url = "https://localhost:5001/api/Leccion/"
const headers = {
    'Accept' : "application/json",
    "Content-Type": "application/json",
  };
  const LeccionService = {
    getLecciones(curso) {
      return fetch(url+curso, {
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
  
