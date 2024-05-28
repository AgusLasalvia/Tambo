using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
	Sistema sistema = Sistema.instancia;



	[HttpGet]
	public ActionResult TareasIncompletas(){
		
		return View();
	}


}