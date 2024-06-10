using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
    Sistema sistema = Sistema.instancia;



    [HttpGet]
    public IActionResult TareasAPeon()
    {
        ViewBag.ListaPeones = sistema.ListarPeones();
        return View();
    }

    [HttpGet]
    public IActionResult TareasIncompletas(string email)
    {
        ViewBag.ListaTareasSinTerminar = sistema.TareasIncompletas(email);
        return View();
    }

}