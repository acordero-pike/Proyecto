const headers = {
    'Accept' : "application/json",
    "Content-Type": "application/json",
  };
  const CursoService = {
    getLecciones() {
      return fetch(URL, {
        method: "GET",
      }).then((response) => response.json());
    },
    deleteLecciones(IdLeccion) {
      return fetch(URL, {
        method: "DELETE",
        headers,
        body: JSON.stringify({IdLeccion: IdLeccion})
      }).then((response) => response.json());
    },
    updateLecciones(body) {
      console.info(body);
      return fetch(URL, {
        method: "PUT",
        headers,
        body: JSON.stringify(body),
      }).then((response) => response.json());
    },
    guardarLecciones(body) {
      return fetch(URL, {
        method: "POST",
        headers,
        body: JSON.stringify(body),
      }).then((response) => response.json());
    },
  };
  