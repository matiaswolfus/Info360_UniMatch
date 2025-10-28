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

public IActionResult SignUp()
{
        return View("CrearCuenta");
       
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido,  string contrasena)
{
    int id = BD.RegistrarUsuario(nombre,apellido,contrasena,UserName);
        HttpContext.Session.SetString("idUser", id.ToString());
        return View("ListaTareas");
   
}
      public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }



[HttpPost]public IActionResult VerInfoUsuario(string Foto){
  
      ViewBag.Usuario = BD.VerInfoUsuario(Foto);
   
    return View("InfoUsuario");

}
public IActionResult InfoUniversidad(string nombre){
   
    BD.InfoUniversidad(nombre);
   
    return View("InfoUniversidad");
}
public IActionResult  InfoCarrera(string nombre){
    
     ViewBag.Carrera = BD.InfoCarrera(nombre);
   
    return View("InfoCarrera");
}
public IActionResult VerReseña(string nombreUni){
    
    ViewBag.Reseña = BD.VerReseña(nombreUni);
   
    return View("VerReseña");

}
public IActionResult Chat(string Foto){
      ViewBag.Chat = BD.Chat(Foto);
   
    return View("Chat");

}
}
