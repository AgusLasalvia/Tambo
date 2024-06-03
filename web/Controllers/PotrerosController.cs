using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class PotrerosController : Controller
{
    Sistema miSistema = Sistema.instancia;

    private readonly ILogger<PotrerosController> _logger;

    public PotrerosController(ILogger<PotrerosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    //-------------------------------------------------------------------//
    // GET's
    // ------------------------------------------------------------------// 
    [HttpGet]
    public IActionResult AnimalAPotrero()
    {
        ViewBag.Potreros = miSistema.ObtenerPotrerosDisponibles();
        if (TempData["AsignarExito"] != null) ViewBag.Exito = TempData["AsignarExito"];
        if (TempData["AsignarError"] != null) ViewBag.Error = TempData["AsignarError"];
        return View();
    }


    //-------------------------------------------------------------------//
    // POST's
    // ------------------------------------------------------------------// 

    [HttpPost]
    public IActionResult AnimalAPotrero(string id, int potrero)
    {
        if (!miSistema.AnimalEspecificoLibre(id))
        {
            TempData["AsignarError"] = "El animal no esta disponible";
            return Redirect("Asignar");
        }
        if (!miSistema.LugarEnPotreroDisponible(potrero))
        {
            TempData["AsignarError"] = "El potrero ya esta lleno";
            return Redirect("Asignar");
        }

        miSistema.AgregarAnimalAPotrero(id, potrero);
        return View();
    }
}