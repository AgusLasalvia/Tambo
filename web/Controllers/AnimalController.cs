using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class AnimalController : Controller
{
    Sistema sistema = Sistema.instancia;


    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ILogger<AnimalController> logger)
    {

        _logger = logger;
    }



    //-------------------------------------------------------------------//
    // GET's
    // ------------------------------------------------------------------// 


    [HttpGet]
    public IActionResult Vacunacion(){
        ViewBag.Animales = sistema.Animales;
        return View();
    }



    //-------------------------------------------------------------------//
    // POST's
    // ------------------------------------------------------------------// 
    [HttpPost]
    public IActionResult AgregarVacuancion(string id,Vacuna vacuna){
        return View();
    }

}