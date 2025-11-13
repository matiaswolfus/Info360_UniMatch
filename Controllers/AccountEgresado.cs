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

    public IActionResult OpinioEgresadosC(){
        return View("OpinioEgresadosC");
    } 
       public IActionResult OpinioEgresadosU(){
        return View("OpinioEgresadosU");
    } 

      public IActionResult OpinioEgresadosCGuardar(int IdCarrera, string descripcion, int IdUsuario){
        BD.GuardarResenia(IdCarrera, descripcion, IdUsuario);
       @ViewBag.Resenias = BD.OpinionesC(IdCarrera);
        return View("VerReseñaCarrera");
    } 
       public IActionResult OpinioEgresadosUGuardar(int IdFacultad, string descripcion, int IdUsuario){
          BD.GuardarResenia(IdFacultad,descripcion, IdUsuario);
            @ViewBag.Resenias = BD.OpinionesU(IdFacultad);
        return View("VerReseñaFacultad");
    } 
 // CREAR LAS CONSULTAS



}