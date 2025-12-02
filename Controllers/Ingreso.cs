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
        return RedirectToAction("Landing", "Home");
    }

    public IActionResult InicioEgresado()
    {
        return View("4PaginaDeInicioEgresado");
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

    [HttpPost]
    public IActionResult SignUp(bool Rol)
    {
        ViewBag.Rol = Rol;
        if (Rol == true)
        {
            return View("3SignUpConsejero");
        }
        else
        {
            return View("3SignUpEstudiante");
        }
    }


    [HttpPost]
    //primero busca el Id segun los datos ingresados, despues lo guarda en la sesion, 
    //despues obtiene la informacion del usuario registrado y redirige dependiendo de su rol
    public IActionResult SignUpGuardarC(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail, string nombreFacultad, bool rol, string fotoPerfil)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, nombreFacultad, gmail, rol, fotoPerfil);
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
    [HttpPost]
    //acá tiene la misma logica que el SignUpGuardarC
    public IActionResult SignUpGuardarE(string username, string nombre, string apellido, string contrasenia, string gmail, bool rol, string fotoPerfil)
    {
        string fotoTituloUni = null;
        string carrera = null;
        string nombreFacultad = null;
        int id = BD.RegistrarUsuario(nombre, apellido, contrasenia, username, fotoTituloUni, carrera, nombreFacultad, gmail, rol, fotoPerfil);
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


    [HttpPost]
    //
    public IActionResult LogInGuardar(string UserName, string contrasena)
    {
        int id = BD.Login(UserName, contrasena);

        if (id != -1) //porque en el metodo logIn chequeo que si es incorrecto id = -1  
        {
            //misma logica que el signUp
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
            return View("3IniciarSesión");
        }
    }



    //CONTROLLERS COMPARTIDOS CON EGRESADOS Y ESTUDIANTES

    public IActionResult InfoUsuario()
    {
        int idUsuario = int.Parse(HttpContext.Session.GetString("idUsuario"));
        ViewBag.Usuario = BD.verInfoUsuario(idUsuario);
        return View("Perfil");
    }

public IActionResult PaginaDeInicioEstudiante(){
    return View("4PaginaDeInicioEstudiante");
}
public IActionResult PaginaDeInicioEgresado(){
    return View("4PaginaDeInicioEgresado");
}

}
