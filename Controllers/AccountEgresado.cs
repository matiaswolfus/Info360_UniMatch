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
/*
      public IActionResult OpinioEgresadosCGuardar(){
        BD.GuardarResenia();
        BD.InfoCarreras();
        return View("CarrerasC&R");
    } 
       public IActionResult OpinioEgresadosUGuardar(){
          BD.GuardarResenia();
          BD.InfoUniversidades();
        return View("UniversidadesC&R");
    } 
*/ // CREAR LAS CONSULTAS
}