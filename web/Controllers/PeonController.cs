using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class PeonController : Controller
{
	Sistema sistema = Sistema.instancia;



	[HttpGet]
	public IActionResult Home()
	{
		return View();
	}

	[HttpGet]
	public ActionResult ListaPeones()
	{
		ViewBag.Listado = sistema.ListarPeones();
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

	[HttpGet]
	public IActionResult PeonEspecifico(string email)
	{
		Peon? peon = sistema.PeonEspecifico(email);
		Console.WriteLine(peon);
		if (peon == null) ViewBag.Error = "Peon no encontrado";
		else ViewBag.Peon = peon;
		return View();
	}


}