using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
	public IActionResult TareasIncompletas()
	{
		if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
		if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
		ViewBag.ListaTareasSinTerminar = sistema.TareasIncompletas(HttpContext.Session.GetString("Email"));
		return View();
	}

	[HttpGet]
	public IActionResult CambioEstado(int id, string comentario)
	{
		try
		{
			if (comentario == "") throw new Exception("Se debe ingresar un comentario");
			sistema.CambiarEstadoTarea(id, comentario);
			TempData["Exito"] = $"Tarea {id} modificada correctamente";
		}
		catch (Exception ex)
		{
			TempData["Error"] = ex.Message;
		}
		return RedirectToAction("TareasIncompletas");
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