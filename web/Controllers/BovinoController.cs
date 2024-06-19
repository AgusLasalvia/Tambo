using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class BovinoController : Controller
{
	Sistema sistema = Sistema.instancia;


	//-------------------------------------------------------------------//
	// GET's
	// ------------------------------------------------------------------// 

	

	[HttpGet]
	public IActionResult RegistroBovino()
	{
		if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
		if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
		if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
		return View();
	}


	//-------------------------------------------------------------------//
	// POST's
	// ------------------------------------------------------------------// 
	

	[HttpPost]
	public IActionResult AltaBovino(TipoAlimentacion tipoAliemntacion, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
	{
        if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
		Bovino b = new Bovino(tipoAliemntacion, genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado);

		if (b == null || fechaNacimiento > DateTime.Today || costoAdquisicion < 0 || costoAlimentacion < 0 || pesoActual < 0)
		{
			TempData["Error"] = "Bovino no creado exitosamente, revise datos";
			return RedirectToAction("RegistroBovino");
		}
		sistema.AltaBovino(b);
		TempData["Exito"] = "Bovino creado exitosamente!!";
		return RedirectToAction("RegistroBovino");

	}
}