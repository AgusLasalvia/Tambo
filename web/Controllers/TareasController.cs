using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
	Sistema sistema = Sistema.instancia;

	[HttpGet]
	public IActionResult TareasIncompletas(){
		
		return View();
	}

	[HttpGet]
	public IActionResult TareasAPeon()
	{
		ViewBag.ListaPeones = sistema.ListarPeones();
		return View();
	}

}