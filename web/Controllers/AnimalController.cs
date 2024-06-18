using System.Security.Cryptography.X509Certificates;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class AnimalController : Controller
{
	Sistema sistema = Sistema.instancia;

    [HttpGet]
    public IActionResult Vacunacion()
    {
        try
        {

        }
        catch (Exception ex) { }
        if (HttpContext.Session.GetString("TipoUsuario") != "Peon") { return RedirectToAction("Login", "Usuario"); }
        if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
        if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
        ViewBag.Animales = sistema.Animales;
        ViewBag.Vacunas = sistema.Vacunas;
        return View();
    }

    [HttpGet]
    public IActionResult ListaAnimales()
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
        ViewBag.Animales = sistema.Animales;
        return View();
    }

    [HttpGet]
    public IActionResult ListaAnimalesPorPeso(double peso, string tipoAnimal)
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
        ViewBag.Animales = sistema.AnimalesPorTipoYPeso(peso, tipoAnimal);
        return View("ListaAnimales");
    }

    [HttpPost]
    public IActionResult AgregarVacuancion(string id, string nombre, DateTime fVacunacion, DateTime fVencimiento)
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Peon") { return View("Login", "Usuario"); }
        sistema.RegistrarVacunacion(id, nombre, fVacunacion, fVencimiento);

        if (fVacunacion >= fVencimiento || fVacunacion > DateTime.Today)
        {
            TempData["Error"] = "Datos mal, verifique";
        }
        else
        {
            TempData["Exito"] = "Vacunacion Agregada exitosamente";
        }
        return Redirect("Vacunacion");
    }



}