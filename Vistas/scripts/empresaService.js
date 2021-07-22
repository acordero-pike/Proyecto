const headers = {
  'Accept' : "application/json",
  "Content-Type": "application/json",
};
export const CursoService = {
  getCursos() {
    return fetch(URL, {
      method: "GET",
    }).then((response) => response.json());
  },
  deleteCurso(idCurso) {
    return fetch(URL, {
      method: "DELETE",
      headers,
      body: JSON.stringify({idCurso: idCurso})
    }).then((response) => response.json());
  },
  updateCurso(body) {
    console.info(body);
    return fetch(URL, {
      method: "PUT",
      headers,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
  saveCurso(body) {
    return fetch(URL, {
      method: "POST",
      headers,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
};
