using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class AnimalController : Controller
{
	Sistema sistema = Sistema.instancia;

    public IActionResult ListaAnimales()
    {
        ViewBag.Animales = sistema.Animales;
        return View();
    }
	
}