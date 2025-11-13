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
   



//LLeva a la view de infouniversidades
public IActionResult SeccionUniEstudiantes(){
       return View("Universidades");
}
public IActionResult SeccionCarreraEstudiantes(){
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
