using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Info360_EFSI.Models;

public class Login : Controller
{
    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger)
    {
            _logger = logger;
    }

    public IActionResult Index()
    {
            return View("index");
    }
        public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
        



/*
public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string contrasena)
{
    // Registrar al usuario y obtener su ID
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName);

    // Guardar el ID del usuario en la sesión
    HttpContext.Session.SetString("idUser", id.ToString());

    // Obtener información del usuario registrado (por ejemplo, su rol)
    var usuario = BD.GetUsuario(id); // Asegúrate de que este método exista en tu clase BD

    // Verificar el rol del usuario y redirigir a la vista correspondiente
    if (usuario.rol == 1)
    {
        return View("LandingEgresados");
    }
    else
    {
        return View("LandingEstudiantes");
    }
}
*/

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

    //2 LLega el bit de rol y los lleva a dos signups diferentes
    IActionResult SignUp(bool Rol){
    @ViewBag.Rol = Rol ;
    if(Rol == true){
    return View( "3SignUpConsejero" );
    }
    else{
    return View( "3SignUpEstudiante");
    }
    }

    //3 guarda los datos ingresados
     [HttpPost]
    public IActionResult SignUpGuardarC(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail, string nombreFacultad, bool Rol)
    {
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail, nombreFacultad,  Rol);
    HttpContext.Session.SetString("idUser", id.ToString());
     ViewBag.Usuario = BD.GetUsuario(id);
         if(ViewBag.Usuario.Rol  == 1 ){
          return View ("4PaginaDeInicioEgresado");
        } else {return View("4PaginaDeInicioEstudiante");
         }
        }
      [HttpPost]
    public IActionResult SignUpGuardarE(string UserName, string nombre, string apellido, string contrasena, string gmail, bool Rol)
    {
        string fotoTituloUni =null;
        string carrera = null;
        string nombreFacultad = null;
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail, nombreFacultad,  Rol);
    HttpContext.Session.SetString("idUser", id.ToString());
     ViewBag.Usuario = BD.GetUsuario(id);
         if(ViewBag.Usuario.Rol  == 1 ){
          return View ("4PaginaDeInicioEgresado");
        } else {return View("4PaginaDeInicioEstudiante");
         }
        }
    

    //LogInGuardar
  [HttpPost]
public IActionResult LogInGuardar(string UserName, string contrasena)
{
    int id = BD.Login(UserName, contrasena);

    if (id != -1)
    {
        HttpContext.Session.SetString("idUser", id.ToString());
        ViewBag.Usuario = BD.GetUsuario(id);

        if (ViewBag.Usuario.Rol == 1)
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