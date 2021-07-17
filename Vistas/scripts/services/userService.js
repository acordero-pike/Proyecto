const requestUrl = `${URL}/usuarios`

const UserService = {
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
    })
  },
};

export default UserService;