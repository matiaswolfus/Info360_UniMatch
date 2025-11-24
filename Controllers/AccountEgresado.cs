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
        string? idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int id = int.Parse(idUserStr);
        Usuario user = BD.GetUsuario(id);
        ViewBag.Usuario = user;

        if (user != null && !string.IsNullOrEmpty(user.carrera))
        {
            ViewBag.IdCarrera = BD.GetIdCarrera(user.carrera, user.idFacultad);
        }

        return View("OpiniondeEgresadoC");
    }

    public IActionResult OpinioEgresadosU()
    {
        string? idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int id = int.Parse(idUserStr);
        Usuario user = BD.GetUsuario(id);
        ViewBag.Usuario = user;

        if (user != null && user.idFacultad > 0)
        {
            ViewBag.IdFacultad = user.idFacultad;
            // Obtener el nombre de la facultad para mostrarlo
            var facultades = BD.infoUniversidades();
            Facultad? facultad = null;
            foreach (var f in facultades)
            {
                if (f.idFacultad == user.idFacultad)
                {
                    facultad = f;
                    break;
                }
            }
            ViewBag.NombreFacultad = facultad?.nombre ?? "Universidad";
        }

        return View("OpiniondeEgresadoU");
    }

    [HttpPost]
    public IActionResult OpinioEgresadosCGuardar(int IdCarrera, string descripcion)
    {
        string? idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int idUsuario = int.Parse(idUserStr);

        if (IdCarrera <= 0)
        {
            Usuario user = BD.GetUsuario(idUsuario);
            if (user != null && !string.IsNullOrEmpty(user.carrera))
            {
                IdCarrera = BD.GetIdCarrera(user.carrera, user.idFacultad);
            }
        }

        if (IdCarrera <= 0)
        {
            ViewBag.Usuario = BD.GetUsuario(idUsuario);
            ViewBag.Error = "No se pudo identificar la carrera. Por favor, asegúrese de tener una carrera asignada en su perfil.";
            return View("OpiniondeEgresadoC");
        }

        BD.GuardarReseniaC(IdCarrera, descripcion, idUsuario);
        return View("ComentarioExito");
    }

    [HttpPost]
    public IActionResult OpinioEgresadosUGuardar(int IdFacultad, string descripcion)
    {
        string? idUserStr = HttpContext.Session.GetString("idUsuario");
        if (idUserStr == null)
        {
            return RedirectToAction("LogIn", "Ingreso");
        }
        int idUsuario = int.Parse(idUserStr);

        if (IdFacultad <= 0)
        {
            Usuario user = BD.GetUsuario(idUsuario);
            if (user != null && user.idFacultad > 0)
            {
                IdFacultad = user.idFacultad;
            }
        }

        if (IdFacultad <= 0)
        {
            Usuario user = BD.GetUsuario(idUsuario);
            ViewBag.Usuario = user;
            ViewBag.Error = "No se pudo identificar la universidad. Por favor, asegúrese de tener una universidad asignada en su perfil.";

            // Volver a cargar el nombre de la facultad para la vista
            if (user != null && user.idFacultad > 0)
            {
                var facultades = BD.infoUniversidades();
                Facultad? facultad = null;
                foreach (var f in facultades)
                {
                    if (f.idFacultad == user.idFacultad)
                    {
                        facultad = f;
                        break;
                    }
                }
                ViewBag.NombreFacultad = facultad?.nombre ?? "Universidad";
            }

            return View("OpiniondeEgresadoU");
        }

        BD.GuardarReseniaU(IdFacultad, descripcion, idUsuario);
        return View("ComentarioExito");
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