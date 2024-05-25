using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class UsuarioController : Controller
{
	Sistema sistema = Sistema.instancia;


	private readonly ILogger<UsuarioController> _logger;

	public UsuarioController(ILogger<UsuarioController> logger)
	{
		_logger = logger;
	}

	//-------------------------------------------------------------------//
	// GET's
	// ------------------------------------------------------------------// 
	[HttpGet]
	public IActionResult Index()
	{
		if (TempData["LoginError"] != null) ViewBag.Error = TempData["LoginError"];
		return View();
	}

	[HttpGet]
	public IActionResult Registro()
	{
		return View();
	}

	[HttpGet]
	public IActionResult AltaPeon()
	{
     
		return View();
	}
  


	// -----------------------------------------------------------------//
	//POST's
	// -----------------------------------------------------------------// 
	[HttpPost]
	public IActionResult BuscarUsuario(string email, string password)
	{
		bool status = sistema.Login(email, password);
		if (status == false)
		{
			TempData["LoginError"] = "Usuario no encontrado";
		}
		return Redirect("Index");
	}

	[HttpPost]
	public IActionResult AltaUsuario(string nombre, string email, string password, bool reside)
	{
		return View();
	}

}
