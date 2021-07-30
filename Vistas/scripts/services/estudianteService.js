const requestUrl = `${URL}/estudiantes`

const estudianteService = {
  getEstudiantes() {
    return fetch(requestUrl, {
      method: "GET",
    }).then((response) => response.json());
  },
  deleteEstudiante(idEstudiante) {
    return fetch(requestUrl, {
      method: "DELETE",
      headers,
      body: JSON.stringify({idEstudiante: idEstudiante})
    }).then((response) => response.json());
  },
  updatEstudiante(body) {
    return fetch(requestUrl, {
      method: "PUT",
      headers,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
  register(body) {
    return fetch(requestUrl, {
      method: "POST",
      headers,
      body: JSON.stringify(body),
    });
  },
};

export default estudianteService;