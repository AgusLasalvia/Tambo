using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class CapatazController : Controller
{
	Sistema sistema = Sistema.instancia;

    public IActionResult Home()
    {
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
        return View();
    }

}