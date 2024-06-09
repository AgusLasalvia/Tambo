using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class PeonController : Controller
{
	Sistema sistema = Sistema.instancia;



	[HttpGet]
	public ActionResult ListaPeones()
	{
		ViewBag.Listado = sistema.ListarPeones();
		return View();
	}

	[HttpGet]
	public IActionResult PeonHome()
	{
		return View();
	}


	[HttpGet]
	public IActionResult DatosPeon(string email)
	{
		Peon? p = sistema.PeonEspecifico(email);
		if (p == null)
		{
			TempData["LoginError"] = "Peon no encontrado";
			return Redirect("Login");
		}
		ViewBag.Peon = p;
		return View();
	}


}