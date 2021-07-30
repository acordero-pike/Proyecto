let ms= null;
document.addEventListener('DOMContentLoaded', async () => {
    // Verificar si el cliente existe
    const parametrosURL = new URLSearchParams(window.location.search);
    ms =  parametrosURL.get('id') ;
console.log(ms);
    mostrar();
});

function mostrar() {
    const dc = document.querySelector("#mensaje");
    dc.innerHTML=`${ms}`
}