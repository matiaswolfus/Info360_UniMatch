using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    {
     [HttpPost]public IActionResult LoginGuardar(string UserName, string Contraseña)
{
    int id = BD.Login(UserName, Contraseña);

    if (id != -1)
    {
        HttpContext.Session.SetString("idUser", id.ToString());
        ViewBag.Usuario = BD.GetUsuario(id);
         return RedirectToAction("ListarTareas", "Home");
    }
    else
    {
        ViewBag.Error = "Login incorrecto";
        return View("IniciarSesión");
    }
}

public IActionResult Login()
{
        return View("IniciarSesión");
}

public IActionResult SignUp()
{
        return View("CrearCuenta");
       
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido,  string contrasena)
{
    int id = BD.RegistrarUsuario(  nombre,  apellido,   contrasena, UserName);

  
        HttpContext.Session.SetString("idUser", id.ToString());
         
        return View("ListaTareas");
   
}
      public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
      
    }



[httpost]public IActionResult VerInfoUsuario(string Foto){
  
    BD.VerInfoUsuario(Foto);
   
    return View("InfoUsuario");

}
public IActionResult InfoUniversidad(string nombre){
   
    BD.InfoUniversidad(nombre);
   
    return View("InfoUniversidad");
}
public IActionResult  InfoCarrera(string nombre){
    
    BD.InfoCarrera(nombre);
   
    return View("InfoCarrera");
}
public IActionResult VerReseña(string nombreUni){
    
    BD.VerReseña(nombreUni);
   
    return View("VerReseña");

}
public IActionResult Chat(string Foto){
    BD.Chat(Foto);
   
    return View("Chat");

}
}
