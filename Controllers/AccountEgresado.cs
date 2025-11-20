using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Info360_EFSI.Models;

namespace Info360_EFSI.Controllers;

public class AccountEgresado : Controller
{
    private readonly ILogger<AccountEgresado> _logger;

    public AccountEgresado(ILogger<AccountEgresado> logger)
    {
        _logger = logger;
    }
    public IActionResult Landing()
{
    return View("Landing");
}


    public IActionResult OpinioEgresadosC(){
         int id = int.Parse(HttpContext.Session.GetString("idUser"));
          ViewBag.Usuario = BD.GetUsuario(id);
       
        return View("OpinioEgresadosC");
    } 
       public IActionResult OpinioEgresadosU(){
         int id = int.Parse(HttpContext.Session.GetString("idUser"));
          ViewBag.Usuario = BD.GetUsuario(id);
        return View("OpinioEgresadosU");
    } 

      public IActionResult OpinioEgresadosCGuardar(int IdCarrera, string descripcion, int IdUsuario){
     //   BD.GuardarReseniaC(IdCarrera, descripcion, IdUsuario);
       ViewBag.Resenias = BD.OpinionesC(IdCarrera);
        return View("VerReseñaCarrera");
    } 
       public IActionResult OpinioEgresadosUGuardar(int IdFacultad, string descripcion, int IdUsuario){
      //    BD.GuardarReseniaU(IdFacultad,descripcion, IdUsuario);
            ViewBag.Resenias = BD.OpinionesU(IdFacultad);
        return View("VerReseñaFacultad");
    } 
 // CREAR LAS CONSULTAS
[HttpPost]
  public IActionResult ReseniasC(int IdCarrera){
       ViewBag.Resenias = BD.OpinionesC(IdCarrera);
        return View("VerReseñaCarrera");
    } 
  public IActionResult ReseniasU(int IdFacultad){
    
            ViewBag.Resenias = BD.OpinionesU(IdFacultad);
        return View("VerReseñaFacultad");
    } 
}