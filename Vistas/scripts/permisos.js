document.addEventListener('DOMContentLoaded', parseJwt);
prearray = JSON.parse( localStorage.getItem('Llave') ) || []  ;
let token="";
 prearray.forEach( ar =>  {  token =ar.token})

function parseJwt () {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
const {Rol} = JSON.parse(jsonPayload)
 console.log(Rol);

};