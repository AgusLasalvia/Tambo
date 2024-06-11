using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
	Sistema sistema = Sistema.instancia;

	// ----------------------------------------------------------------------- //
	// GET'S
	// ----------------------------------------------------------------------- //

	[HttpGet]
	public IActionResult TareasAPeon()
	{
		ViewBag.ListaPeones = sistema.ListarPeones();
		return View();
	}

	[HttpGet]
	public IActionResult AsignarTarea(string id)
	{
		ViewBag.PeonEspecifico = sistema.PeonEspecifico(id);
		return View();
	}

	[HttpGet]
	public IActionResult TareasIncompletas(string email)
	{
		ViewBag.ListaTareasSinTerminar = sistema.TareasIncompletas(email);
		return View();
	}

	// ----------------------------------------------------------------------- //
	// POST'S
	// ----------------------------------------------------------------------- //

	[HttpPost]
	public IActionResult AsignarTarea(string email, string descripcion, DateTime fechaIngreso, DateTime fechaCierre)
	{
		try
		{
			if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(email)) throw new Exception("Datos nulos, revisar");
			sistema.AltaTarea(email, descripcion, fechaIngreso, fechaCierre);
			TempData["Exito"] = "Tarea creada correctamente";
			return RedirectToAction("ListaPeones", "Peon");
		}
		catch (Exception ex)
		{
			TempData["Error"] = ex.Message;
			return RedirectToAction("AsignarTarea/", "Peon");
		}
	}

	// [HttpPost]
	// public IActionResult CambiarEstadoTarea()
	// {

	// }

}