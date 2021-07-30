const requestUrl = `${URL}/usuarios`

prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
prearray.forEach( ar =>  {  token =ar.token})

  const myHeaders = new Headers();
myHeaders.append('Authorization', `Bearer ${token}  `);
myHeaders.append('Content-Type', 'application/json'); 
const UserService = {
  getUsuarios() {
    return fetch(requestUrl, {
      method: "GET",
    }).then((response) => response.json());
  },
  deleteUsuario(idUsuario) {
    return fetch(requestUrl, {
      method: "DELETE",
      headers:myHeaders,
      body: JSON.stringify({idUsuario: idUsuario})
    }).then((response) => response.json());
  },
  updateUsuario(body) {
    return fetch(requestUrl, {
      method: "PUT",
      headers:myHeaders,
      body: JSON.stringify(body),
    }).then((response) => response.json());
  },
  register(body) {
    return fetch(requestUrl, {
      method: "POST",
      headers:myHeaders,
      body: JSON.stringify(body),
    })
  },
};

export default UserService;