using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class PeonController : Controller
{
	Sistema sistema = Sistema.instancia;



	[HttpGet]
	public IActionResult Home()
	{
		if (HttpContext.Session.GetString("TipoUsuario") == null) { return RedirectToAction("Login", "Usuario"); }

		return View();
	}

	[HttpGet]
	public ActionResult ListaPeones()
	{
		if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
		ViewBag.Listado = sistema.ListarPeones();
		if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
		if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
		return View();
	}


	[HttpGet]
	public IActionResult DatosPeon(string email)
	{
		if (HttpContext.Session.GetString("TipoUsuario") == null) { return RedirectToAction("Login", "Usuario"); }
		Peon? p = sistema.PeonEspecifico(email);
		if (p == null)
		{
			TempData["LoginError"] = "Peon no encontrado";
			return Redirect("Login");
		}
		ViewBag.Peon = p;
		return View();
	}

	[HttpGet]
	public IActionResult PeonEspecifico(string email)
	{
		if (HttpContext.Session.GetString("TipoUsuario") == null) { return RedirectToAction("Login", "Usuario"); }
		Peon? peon = sistema.PeonEspecifico(email);
		if (peon == null) ViewBag.Error = "Peon no encontrado";
		else ViewBag.Peon = peon;
		return View();
	}


}