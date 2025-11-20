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
    success : function(dataUsuario)
    {
      $("#modalInfo").html("Usuario " + dataUsuario.nombre);
      let info = `
      <p>Nombre${dataUsuario.nombre}</p>
      <p>Apellido${dataUsuario.apellido}</p>
      <p>Gmail${dataUsuario.gmail}</p>
      <p>Carrera: ${dataUsuario.carrera}</p>
      <p>Rol: ${dataUsuario.rol}</p>
  `;

    }
    
  }

  )
}
