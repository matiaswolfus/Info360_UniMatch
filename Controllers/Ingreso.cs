using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Info360_EFSI.Models;

public class Login : Controller
{
    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger)
    {
            _logger = logger;
    }

    public IActionResult Index()
    {
            return View("index");
    }
        public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
        
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

    public IActionResult loguearse()
    {
       return View("IniciarSesión");
    }

    public IActionResult SignUp()
    {
        return View("CrearCuenta"); 
    }
    
public IActionResult SignUpElección(){return View(SignUpSeleccion) ;  }



IActionResult SignUp(bit Rol){
    
    @ViewBag.Rol = Rol ;

if(Rol == 1){
return View(SignUpConsejero);}
else{
 return View(SignUpEstudiante) ;  
}
}


IActionResult LogIn(){return View(IniciarSesión) ;  }
}


