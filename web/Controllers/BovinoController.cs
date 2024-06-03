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
	public IActionResult Vacunacion()
	{
		
		if (TempData["VacunacionExito"] != null) ViewBag.Exito = TempData["VacunacionExito"];
		ViewBag.Animales = sistema.Animales;
		return View();
	}

	[HttpGet]
	public IActionResult RegistroBovino()
	{
		if (TempData["AltaBovinoError"] != null) ViewBag.Error = TempData["AltaBovinoError"];
		if (TempData["AltaBovinoExito"] != null) ViewBag.Exito = TempData["AltaBovinoExito"];
		return View();
	}


	//-------------------------------------------------------------------//
	// POST's
	// ------------------------------------------------------------------// 
	[HttpPost]
	public IActionResult AgregarVacuancion(string id, Vacuna vacuna)
	{
		sistema.AgregarVacunacion(id, vacuna);
		TempData["VacunacionExito"] = "Vacunacion Agregada exitosamente";
		return Redirect("Vacunacion");
	}


	[HttpPost]
	public IActionResult AltaBovino(TipoAlimentacion tipoAliemntacion, TipoGenero genero, string raza, DateTime fechaNacimiento, double costoAdquisicion, double costoAlimentacion, double pesoActual, bool hibrido, List<Vacunacion> vacunas, bool estado)
	{
		Bovino b = new Bovino(tipoAliemntacion, genero, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, vacunas, estado);

		if (b == null)
		{
			TempData["AltaBovinoError"] = "Bovino no creado exitosamente, revise datos";
			return Redirect("RegistroBovino");
		}
		sistema.AltaBovino(b);
		TempData["AltaBovinoExito"] = "Bovino creado exitosamente!!";
		return Redirect("RegistroBovino");

	}
}