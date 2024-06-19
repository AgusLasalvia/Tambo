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
		if (HttpContext.Session.GetString("TipoUsuario") != "Peon") { return RedirectToAction("Login", "Usuario"); }
		ViewBag.ListaPeones = sistema.ListarPeones();
		return View();
	}

	[HttpGet]
	public IActionResult AsignarTarea(string id)
	{
		if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }
		ViewBag.PeonEspecifico = sistema.PeonEspecifico(id);
		if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
		if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
		return View();
	}

	[HttpGet]
	public IActionResult TareasIncompletas()
	{
		if (HttpContext.Session.GetString("TipoUsuario") != "Peon") { return RedirectToAction("Usuario", "Login"); }

		if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
		if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
		ViewBag.ListaTareasSinTerminar = sistema.TareasIncompletas(HttpContext.Session.GetString("Email"));
		ViewBag.ListaTareasSinTerminar.Sort();
		return View();
	}

	[HttpGet]
	public IActionResult CambioEstado(int id, string comentario)
	{
		if (HttpContext.Session.GetString("TipoUsuario") != "Peon") { return RedirectToAction("Login", "Usuario"); }

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
		if (HttpContext.Session.GetString("TipoUsuario") != "Capataz") { return RedirectToAction("Login", "Usuario"); }

		try
		{
			if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(email)) throw new Exception("Datos nulos, revisar");
			sistema.AltaTarea(email, descripcion, fechaIngreso, fechaCierre);
			TempData["Exito"] = "Tarea creada correctamente";
			return RedirectToAction("ListaPeones", "Peon");
		}
		catch (Exception ex)
		{
			TempData["Error"] = "Datos mal, verifique";
			return Redirect("~/Tarea/AsignarTarea/" + email);
		}
	}
}