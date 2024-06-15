using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class UsuarioController : Controller
{
	Sistema sistema = Sistema.instancia;


	//-------------------------------------------------------------------//
	// GET's
	// ------------------------------------------------------------------// 


	[HttpGet]
	public IActionResult Index()
	{
		return Redirect("~/Usuario/Login");
	}


	// Funciones para el Login
	[HttpGet]
	public IActionResult Login()
	{
		if (TempData["AltaExito"] != null) ViewBag.Exito = TempData["AltaExito"];
		if (TempData["LoginError"] != null) ViewBag.Error = TempData["LoginError"];
		return View();
	}

	[HttpGet]
	public IActionResult Logout()
	{
		HttpContext.Session.Clear();
		return Redirect("~/Usuario/Login");
	}


	// Funciones para el Registro
	[HttpGet]
	public IActionResult Registro()
	{
		if (TempData["AltaError"] != null) ViewBag.Error = TempData["AltaError"];
		return View();
	}



	// -----------------------------------------------------------------//
	//POST's
	// -----------------------------------------------------------------// 
	[HttpPost]
	public IActionResult BuscarUsuario(string email, string password)
	{
		Empleado? empleado = sistema.Login(email, password);
		if (empleado == null)
		{
			TempData["LoginError"] = "Usuario no encontrado";
			return Redirect("Login");
		}
		if (empleado is Peon)
		{
			HttpContext.Session.SetString("NombreUsuario", empleado.Nombre);
			HttpContext.Session.SetString("Email", empleado.Email);
			HttpContext.Session.SetString("TipoUsuario", empleado.GetTipo());
			return RedirectToAction("Home", "Peon");

		}
		HttpContext.Session.SetString("NombreUsuario", empleado.Nombre);
		HttpContext.Session.SetString("Email", empleado.Email);
		HttpContext.Session.SetString("TipoUsuario", empleado.Email);
		return RedirectToAction("Home", "Capataz");

	}




	[HttpPost]
	public IActionResult AltaUsuario(string nombre, string email, string password, bool reside)
	{

		if (sistema.VerificarUsuario(email))
		{
			TempData["AltaError"] = "El usuario ya existe";
			return Redirect("Registro");
		}
		bool status = sistema.AltaUsuario(nombre, email, password, reside);
		if (!status)
		{
			TempData["AltaError"] = "Usuario no generado exitosamente, revise datos";
			return Redirect("Registro");
		}

		TempData["AltaExito"] = "Usuario generado exitosamente";
		return Redirect("Login");


	}
}
