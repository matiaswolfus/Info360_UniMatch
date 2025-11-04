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

    public IActionResult SignUp()
    {
        return View("CrearCuenta");
       
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string contrasena)
{
    // Registrar al usuario y obtener su ID
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName);

    // Guardar el ID del usuario en la sesión
    HttpContext.Session.SetString("idUser", id.ToString());

    // Obtener información del usuario registrado (por ejemplo, su rol)
    var usuario = BD.GetUsuario(id); // Asegúrate de que este método exista en tu clase BD

    // Verificar el rol del usuario y redirigir a la vista correspondiente
    if (usuario.rol == 1)
    {
        return View("LandingEgresados");
    }
    else
    {
        return View("LandingEstudiantes");
    }
}
public IActionResult SeccionUniEstudiantes(){
       return View("Universidades");
}
public IActionResult SeccionCarreraEstudiantes(){
       return View("Carreras");
}

public IActionResult SeccionUniEgresados(){
       return View("UniversidadesC&R");
}
public IActionResult SeccionCarreraEgresados(){
       return View("CarrerasC&R");
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string contrasena, string fotoTituloUni, string carrera, string gmail)
{
    int id = BD.RegistrarUsuario(nombre, apellido, contrasena, UserName, fotoTituloUni, carrera, gmail);
    HttpContext.Session.SetString("idUser", id.ToString());
    return View("ListaTareas");
}




    public IActionResult VerInfoUsuario(int idUsuario)
    {
        ViewBag.Usuario = BD.VerInfoUsuario(Foto);
        return View("InfoUsuario"); 
    }

    public IActionResult InfoUniversidad(string nombre)
    {
        Universidad universidad = BD.InfoUniversidad(nombre);
        ViewBag.Universidad = universidad;
        return View("InfoUniversidad");
    }
    public IActionResult InfoPorNombreYFacultad(string nombreCarrera, string nombreFacultad)
    {
        ViewBag.Carrera = BD.InfoPorNombreYFacultad(nombreCarrera, nombreFacultad);
        return View("InfoCarrera");
    }

    public IActionResult VerReseña(string nombreUni)
    {
        ViewBag.Reseña = BD.VerReseña(nombreUni);
        return View("VerReseña");
    }

    // Pantalla de selección de propósito
    public IActionResult SignUpSeleccion()
    {
        return View("SignUpSeleccion"); // Vista con botones para "Quiero informarme" y "Quiero aconsejar" osea la parte en la que se separan los dos tipos de usuario
    }

    // Registro para estudiantes (informarse)
    public IActionResult SignUpEstudiante()
    {
        return View("SignUpEstudiante"); // Formulario para estudiantes
    }

    [HttpPost]
    public IActionResult SignUpEstudianteGuardar(string nombre, string apellido, string gmail, string contrasena, string username, string carrera)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, username, string.Empty, carrera, gmail);
        HttpContext.Session.SetString("idUser", id.ToString());
        return RedirectToAction("Index");
    }

    // Registro para consejeros (aconsejar)
    public IActionResult SignUpConsejero()
    {
        return View("SignUpConsejero"); // Aca hay que mostrar formulario para consej
    }

    [HttpPost]
    public IActionResult SignUpConsejeroGuardar(string nombre, string apellido, string gmail, string contrasena, string username, string carrera, string fotoTituloUni)
    {
        int id = BD.RegistrarUsuario(nombre, apellido, contrasena, username, fotoTituloUni, carrera, gmail);
        // 
        HttpContext.Session.SetString("idUser", id.ToString());
        return RedirectToAction("Index");
    }






/*INFO CARRERA*/

IActionResult InfoCarreras(){

BD.InfoCarreras();

@ViewBag.Foto = Foto;
@ViewBag.Nombre = Nombre;
@ViewBag.Id = IdCa;

return View("Carreras");
}


IActionResult Carreras(int Id){
BD.infoCarrera();
@ViewBag.Foto = Foto;
@ViewBag.Nombre = Nombre;
@ViewBag.CantMaterias = CantMaterias;
@ViewBag.Duracion = Duracion;
@ViewBag.Descripcion = Descripcion;
}



/*INFO UNIVERSIDAD*/

IActionResult InfoUniversidades(){

BD.InfoUniversidades();

@ViewBag.Foto = Foto;
@ViewBag.Nombre = Nombre;
@ViewBag.Id = IdUniversidad;

return View("Universidades");
}


IActionResult Universidades(int Id){
    BD.infoUniversidad(Id);
            @ViewBag.Foto = Foto;
          @ViewBag.Nombre = Nombre;
          @ViewBag.direccion = direccion;
          @ViewBag.contacto = contacto;
          @ViewBag.fotoFacultad = fotoFacultad;
          @ViewBag.Becas = Becas;
          @ViewBag.cantCarreras = cantCarreras;
          @ViewBag.Cuota = this.Cuota;
          @ViewBag.TipoGestion = TipoGestion;

   return View("InfoUniversidad");

}

}
