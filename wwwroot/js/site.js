// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleMenu() {
    const nav = document.querySelector('nav');
    nav.classList.toggle('active');
  }
// --> INFO USUARIO CAMBIAR
function GetInfo(idserie)
$.ajax({
});
url: '/Home/VerInfo',
data: { IdSerie: idserie }, type: 'GET',
dataType: 'json',
success: function(response) {
}
$("#ModalTitle").text("Serie + response.nombre);
const body = response.añoInicio + "<br>" + response.sinopsis; $("#ModalBody").html(body);
}
//
