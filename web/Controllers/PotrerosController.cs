using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class PotrerosController : Controller
{
    Sistema miSistema = Sistema.instancia;

    //-------------------------------------------------------------------//
    // GET's
    // ------------------------------------------------------------------// 

    [HttpGet]
    public IActionResult ListaPotreros()
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
        ViewBag.Potreros = miSistema.ListaPotreros();
        ViewBag.Potreros.Sort();
        return View();
    }

    [HttpGet]
    public IActionResult AnimalAPotrero()
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
        ViewBag.Potreros = miSistema.ObtenerPotrerosDisponibles();
        ViewBag.Animales = miSistema.ListadoAnimalesLibre();
        if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
        if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
        return View();
    }


    //-------------------------------------------------------------------//
    // POST's
    // ------------------------------------------------------------------// 

    [HttpGet]
    public IActionResult AsignarAnimalAPotrero(string id, int potrero)
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }

        if (!miSistema.AnimalEspecificoLibre(id))
        {
            TempData["Error"] = "El animal no esta disponible";
        }
        if (!miSistema.LugarEnPotreroDisponible(potrero))
        {
            TempData["Error"] = "El potrero ya esta lleno";
        }

        miSistema.AgregarAnimalAPotrero(id, potrero);
        return RedirectToAction("AnimalAPotrero");
    }
}