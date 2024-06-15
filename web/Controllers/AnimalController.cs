using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class AnimalController : Controller
{
	Sistema sistema = Sistema.instancia;

    [HttpGet]
    public IActionResult Vacunacion()
    {

        if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
        if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
        ViewBag.Animales = sistema.Animales;
        ViewBag.Vacunas = sistema.Vacunas;
        return View();
    }

    [HttpGet]
    public IActionResult ListaAnimales()
    {
        // ViewBag.Animales = sistema.Animales;
        return View();
    }

    [HttpPost]
    public IActionResult AgregarVacuancion(string id, string nombre, DateTime fVacunacion, DateTime fVencimiento)
    {

        sistema.RegistrarVacunacion(id, nombre, fVacunacion, fVencimiento);
        TempData["Exito"] = "Vacunacion Agregada exitosamente";
        return Redirect("Vacunacion");
    }


    // [HttpPost]
    public IActionResult ListaAnimalesPorPeso(double peso, string tipoAnimal)
    {
        ViewBag.Animales = sistema.AnimalesPorTipoYPeso(peso, tipoAnimal);
        return View("ListaAnimales");
    }
	
}