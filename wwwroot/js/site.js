// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleMenu() {
    const nav = document.querySelector('nav');
    nav.classList.toggle('active');
  }
function tomarInformacion(idusuario)
{
$.ajax(

  {
    url: '/Home/verInfoUsuario',
    data: {idUsuario: idusuario},
    type: 'GET',
    dataType: 'Json',
    success : function(response)
    {
      let info = `
      <p>Nombre${response.nombre}</p>
      <p>Apellido${response.apellido}</p>
      <p>Gmail${response.gmail}</p>
      <p>Carrera: ${response.carrera}</p>
      <p>Rol: ${response.rol}</p>
  `;
      $("#modal").html(info);
    }
    
  }

  )
}
