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
        return View("Landing");
    }
   



//LLeva a la view de infouniversidades
public IActionResult SeccionUniEstudiantes(){
    List<Facultad> Universidades = BD.infoUniversidades();
    ViewBag.Universidades =Universidades;
       return View("Universidades");
}
public IActionResult SeccionCarreraEstudiantes(){
       List< Carrera> Carreras = BD.infoCarreras();
    ViewBag.Carreras = Carreras;
       return View("Carreras");
}



//Consigue la info especifica de una universidad
    public IActionResult InfoUniversidad(int id)
    {
        Facultad universidad = BD.InfoUniversidad(id);
        ViewBag.Universidad = universidad;
        return View("InfoUniversidad");
    }
     public IActionResult InfoCarrera(int id)
    {
        Carrera carrera = BD.InfoCarrera(id);
        ViewBag.carrera = carrera;
        return View("InfoCarrera");
    }
    



//LLeva a la view de PARA CHATS
public IActionResult SeccionUniResenias(){
    List<Facultad> Universidades = BD.infoUniversidades();
    ViewBag.Universidades =Universidades;
       return View("UniversidadesC&R");
}
public IActionResult SeccionCarreraResenias(){
       List< Carrera> Carreras = BD.infoCarreras();
    ViewBag.Carreras = Carreras;
       return View("CarrerasC&R");
}









  
/*
    [HttpPost]
    public IActionResult SignUpConsejeroGuardar(string nombre, string apellido, string gmail, string contrasena, string username, string carrera, string fotoTituloUni)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, username, fotoTituloUni, carrera, gmail);
        // 
        HttpContext.Session.SetString("idUser", id.ToString());
        return RedirectToAction("Index");
    }



*/







}
