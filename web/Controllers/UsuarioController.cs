using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class UsuarioController : Controller
{
    Sistema sistema = Sistema.instancia;


    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {

        _logger = logger;
    }

    //-------------------------------------------------------------------//
    // GET's
    // ------------------------------------------------------------------// 

    // Funciones para el Login
    [HttpGet]
    public IActionResult Index()
    {
        return Redirect("~/Usuario/Login");
    }



    [HttpGet]
    public IActionResult Login()
    {
        if (TempData["LoginError"] != null) ViewBag.Error = TempData["LoginError"];
        return View();
    }



    // Funciones para el Registro
    [HttpGet]
    public IActionResult Registro()
    {
        if (TempData["AltaError"] != null) ViewBag.Error = TempData["AltaError"];
        if (TempData["AltaExito"] != null) ViewBag.Exito = TempData["AltaExito"];
        return View();
    }

    [HttpGet]
    public IActionResult RegistroBovino()
    {
        if (TempData["AltaBovinoError"] != null) ViewBag.Error = TempData["AltaBovinoError"];
        if (TempData["AltaBovinoExito"] != null) ViewBag.Exito = TempData["AltaBovinoExito"];
        return View();
    }


    [HttpGet]
    public IActionResult PeonHome(){
        return View();
    }


    [HttpGet]
    public IActionResult DatosPeon(string email){
        Peon? p = sistema.PeonEspecifico(email);
        if (p == null) {
            TempData["LoginError"] = "Peon no encontrado";
            return Redirect("Login");
        }
        ViewBag.Peon = p;
        return View();
    }


    // -----------------------------------------------------------------//
    //POST's
    // -----------------------------------------------------------------// 
    [HttpPost]
    public IActionResult BuscarUsuario(string email, string password)
    {
        Empleado? empleado = sistema.Login(email, password);
        if (empleado == null)
        {
            TempData["LoginError"] = "Usuario no encontrado";
            return Redirect("Login");
        }
        if (empleado is Peon)
        {
            return Redirect("~/Usuario/PeonHome");
        }
        return Redirect("~/Usuario/PeonHome");
    }




    [HttpPost]
    public IActionResult AltaUsuario(string nombre, string email, string password, bool reside)
    {

		if(sistema.VerificarUsuario(email)){
			TempData["AltaError"] = "El usuario ya existe";
            return Redirect("Registro");
        }
		bool status = sistema.AltaUsuario(nombre, email, password, reside);
        if(!status){
            TempData["AltaError"] = "Usuario no generado exitosamente, revise datos";
            return Redirect("Registro");
        }

        TempData["AltaExito"] = "Usuario generado exitosamente";
        return Redirect("Registro");

		
    }

    [HttpPost]
    public IActionResult AltaBovino(TipoAlimentacion tipoAliemntacion, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
    {
        Bovino b = new Bovino(tipoAliemntacion, genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado);

        if (b == null)
        {
            TempData["AltaBovinoError"] = "Bovino no creado exitosamente, revise datos";
            return Redirect("RegistroBovino");
        }
        sistema.AltaBovino(b);
        TempData["AltaBovinoExito"] = "Bovino creado exitosamente!!";
        return Redirect("RegistroBovino");

    }



}
