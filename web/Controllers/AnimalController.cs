using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class AnimalController : Controller
{
	Sistema sistema = Sistema.instancia;


    // [HttpGet]
    public IActionResult ListaAnimales()
    {
        // ViewBag.Animales = sistema.Animales;
        return View();
    }

    // [HttpPost]
    public IActionResult ListaAnimalesPorPeso(double peso, string tipoAnimal)
    {
        ViewBag.Animales = sistema.AnimalesPorTipoYPeso(peso, tipoAnimal);
        return View("ListaAnimales");
    }
	
}