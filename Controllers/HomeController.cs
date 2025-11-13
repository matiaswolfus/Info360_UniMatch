using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Info360_EFSI.Models;

namespace Info360_EFSI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("index");
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

    //2 LLega el bit de rol y los lleva a dos signups diferentes
    IActionResult SignUp(bit Rol){
    @ViewBag.Rol = Rol 
    if(Rol == 1){
    return View( "3SignUpConsejero" )}
    else{
    return View( "3SignUpEstudiante")  
    }
    }

    //3 guarda los datos ingresados
     [HttpPost]
    public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail, string nombreFacultad, bit Rol)
    {
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail, nombreFacultad,  Rol);
    HttpContext.Session.SetString("idUser", id.ToString());
         if{ 
          Rol = 1 ReturnView ("4PaginaDeInicioEgresado")
        } else {return View("4PaginaDeInicioEstudiante")
         }
        }
    }
    

    //LogInGuardar
     [HttpPost]
    public IActionResult LogInGuardar(string Username, string  contrasena){
        int id = BD.Login(UserName, contrasena);

    if (id != -1)
    {
        HttpContext.Session.SetString("idUser", id.ToString());
        ViewBag.Usuario = BD.GetUsuario(id);
        if(ViewBag.Usuario.Rol == 1){
             return View("4PaginaDeInicioEgresado");
        }else{
          return View("4PaginaDeInicioEstudiante");
        }
    }
    else
    {
        ViewBag.Error = "Login incorrecto";
        return View("3IniciarSesión");
    }
    }












public IActionResult SeccionUniEstudiantes(){
       return View("Universidades");
}
public IActionResult SeccionCarreraEstudiantes(){
       return View("Carreras");
}

public IActionResult SeccionUniEgresados(){
       return View("UniversidadesC&R");
}
public IActionResult SeccionCarreraEgresados(){
       return View("CarrerasC&R");
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail)
{
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail);
    HttpContext.Session.SetString("idUser", id.ToString());
    return View("");
}




    public IActionResult VerInfoUsuario(int idUsuario)
    {
        ViewBag.Usuario = BD.VerInfoUsuario(idUsuario);
        return View("InfoUsuario"); 
    }

    public IActionResult InfoUniversidad(int id)
    {
        Facultad universidad = BD.InfoUniversidad(id);
        ViewBag.Universidad = universidad;
        return View("InfoUniversidad");
    }
    
    public IActionResult InfoPorNombreYFacultad(string nombreCarrera, string nombreFacultad)
    {
        ViewBag.Carrera = BD.InfoPorNombreYFacultad(nombreCarrera, nombreFacultad);
        return View("InfoCarrera");
    }


    public IActionResult VerReseña(int  id)
    {
        ViewBag.Reseña = BD.VerReseña(id);
        return View("VerReseña");
    }

   

    //3 Registro para estudiantes (informarse)
    public IActionResult SignUpEstudiante()
    {
        return View("SignUpEstudiante"); // Formulario para estudiantes
    }

    [HttpPost]
    public IActionResult SignUpEstudianteGuardar(string nombre, string apellido, string gmail, string contrasena, string username, string carrera)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, username, string.Empty, carrera, gmail);
        HttpContext.Session.SetString("idUser", id.ToString());
        return RedirectToAction("Index");
    }

    // Registro para consejeros (aconsejar)
    public IActionResult SignUpConsejero()
    {
        return View("SignUpConsejero"); // Aca hay que mostrar formulario para consej
    }

    [HttpPost]
    public IActionResult SignUpConsejeroGuardar(string nombre, string apellido, string gmail, string contrasena, string username, string carrera, string fotoTituloUni)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, username, fotoTituloUni, carrera, gmail);
        // 
        HttpContext.Session.SetString("idUser", id.ToString());
        return RedirectToAction("Index");
    }












    public IActionResult InfoCarreras(){

   @ViewBag.Carrera = BD.InfoCarreras();

    return View("Carreras");
    }


    public IActionResult Carreras(int Id){
   @ViewBag.Carrera =  BD.InfoCarrera(Id);
    return View("InfoCarrera");
    }



public IActionResult InfoUniversidades(){

@ViewBag.Universidades = BD.InfoUniversidades(); // CREAR UNO EN BD



return View("Universidades");
}


public IActionResult Universidades(int Id)
{
    @ViewBag.Facultad = BD.InfoUniversidad(Id);
   
   return View("InfoUniversidad");

}

}
