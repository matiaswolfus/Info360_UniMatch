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

    public IActionResult OpinioEgresadosC()
    {
        string idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int id = int.Parse(idUserStr);
        ViewBag.Usuario = BD.GetUsuario(id);

        return View("OpiniondeEgresadoC");
    }
    public IActionResult OpinioEgresadosU()
    {
        string idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int id = int.Parse(idUserStr);
        ViewBag.Usuario = BD.GetUsuario(id);
        return View("OpiniondeEgresadoU");
    }

    [HttpPost]
    public IActionResult OpinioEgresadosCGuardar(int IdCarrera, string descripcion)
    {
        string idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int idUsuario = int.Parse(idUserStr);
        BD.GuardarReseniaC(IdCarrera, descripcion, idUsuario);
        ViewBag.Resenias = BD.OpinionesC(IdCarrera);
        ViewBag.IdCarrera = IdCarrera;
        return View("OpiniondeEgresadoC");
    }


    public IActionResult OpinioEgresadosUGuardar(int IdFacultad, string descripcion, int IdUsuario)
    {
        //    BD.GuardarReseniaU(IdFacultad,descripcion, IdUsuario);
        ViewBag.Resenias = BD.OpinionesU(IdFacultad);
        return View("Home/VerReseñaFacultad");
    }
    // CREAR LAS CONSULTAS
    [HttpPost]
    public IActionResult ReseniasC(int IdCarrera)
    {
        ViewBag.Resenias = BD.OpinionesC(IdCarrera);
        return View("Home/VerReseñaCarrera");
    }
    public IActionResult ReseniasU(int IdFacultad)
    {

        ViewBag.Resenias = BD.OpinionesU(IdFacultad);
        return View("Home/VerReseñaFacultad");
    }
}