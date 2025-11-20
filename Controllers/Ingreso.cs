using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Info360_EFSI.Models;

namespace Info360_EFSI.Controllers;
public class IngresoController : Controller
{
    private readonly ILogger<IngresoController> _logger;

    public IngresoController(ILogger<IngresoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Landing");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }





public IActionResult SignUpGuardar( string nombre, string apellido, string contrasenia,string username, string? fotoTituloUni, string? carrera, string? facultad, string gmail, bool rol)
{
    // Registrar al usuario y obtener su ID
    int id = BD.RegistrarUsuario(nombre, apellido, contrasenia, username, fotoTituloUni, carrera, facultad, gmail, rol);

    // Guardar el ID del usuario en la sesión
    HttpContext.Session.SetString("idUsuario", id.ToString());

    // Obtener información del usuario registrado (por ejemplo, su rol)
    var usuario = BD.GetUsuario(id); // Asegúrate de que este método exista en tu clase BD

    // Verificar el rol del usuario y redirigir a la vista correspondiente
    if (usuario.rol == true)
    {
        return View("4PaginaDeInicioEgresado");
    }
    else
    {
        return View("4PaginaDeInicioEstudiante");
    }
}


  //1 Pantalla de selección de propósito
    public IActionResult SignUpSeleccion()
    {
        return View("2SignUpSeleccion"); // Vista con botones para "Quiero informarme" y "Quiero aconsejar" osea la parte en la que se separan los dos tipos de usuario
    }
    //1 pantalla de LogIn
     public IActionResult LogIn()
    {
        return View("3IniciarSesión");
    }

    IActionResult SignUp(bool Rol){
    ViewBag.Rol = Rol ;
    if(Rol == true){
    return View( "3SignUpConsejero" );
    }
    else{
    return View( "3SignUpEstudiante");
    }
    }

   
     [HttpPost]
    public IActionResult SignUpGuardarC(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail, string nombreFacultad, bool rol)
    {
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail, nombreFacultad,  rol);
    HttpContext.Session.SetString("idUsuario", id.ToString());
     ViewBag.Usuario = BD.GetUsuario(id);
         if(ViewBag.Usuario.rol == true){
          return View ("4PaginaDeInicioEgresado");
        } else {return View("4PaginaDeInicioEstudiante");
         }
        }
      [HttpPost]
    public IActionResult SignUpGuardarE(string username, string nombre, string apellido, string contrasenia, string gmail, bool rol)
    {
        string fotoTituloUni =null;
        string carrera = null;
        string nombreFacultad = null;
    int id = BD.RegistrarUsuario(nombre, apellido, contrasenia, username, fotoTituloUni, carrera, gmail, nombreFacultad, rol);
    HttpContext.Session.SetString("idUsuario", id.ToString());
    ViewBag.Usuario = BD.GetUsuario(id);
         if(ViewBag.Usuario.rol == true)
        {
          return View ("4PaginaDeInicioEgresado");
        } 
        else 
        {
            return View("4PaginaDeInicioEstudiante");
        }
        }
    

  [HttpPost]
public IActionResult LogInGuardar(string UserName, string contrasena)
{
    int id = BD.Login(UserName, contrasena);

    if (id != -1)
    {
        HttpContext.Session.SetString("idUsuario", id.ToString());
        ViewBag.Usuario = BD.GetUsuario(id);

        if (ViewBag.Usuario.rol == true)
        {
            return View("4PaginaDeInicioEgresado");
        }
        else
        {
            return View("4PaginaDeInicioEstudiante");
        }
    }
    else
    {
        ViewBag.Error = "Login incorrecto";
        return View("3IniciarSesion");
    }
}



//CONTROLLERS COMPARTIDOS CON EGRESADOS Y ESTUDIANTES

 public IActionResult VerInfoUsuario(int idUsuario)
    {
        ViewBag.Usuario = BD.verInfoUsuario(idUsuario);
        return View("InfoUsuario"); 
    }



}