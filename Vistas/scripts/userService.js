const requestUrl = `${URL}usuarios`

const usuariosService = {
  getUsuarios() {
    return fetch(requestUrl, {
      method: "GET",
    }).then((response) => response.json());
  },
  deleteUsuario(idUsuario) {
    return fetch(requestUrl, {
      method: "DELETE",
      headers,
      body: JSON.stringify({idUsuario: idUsuario})
    }).then((response) => response.json());
  },
  updateUsuario(body) {
    console.info(body);
    return fetch(requestUrl, {
      method: "PUT",
      headers,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
  saveUsuario(body) {
    console.info(body);
    return fetch(requestUrl, {
      method: "POST",
      headers,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
};
