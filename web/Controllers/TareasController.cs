using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
	Sistema sistema = Sistema.instancia;


	private readonly ILogger<TareaController> _logger;

	public TareaController(ILogger<TareaController> logger)
	{

		_logger = logger;
	}


	[HttpGet]
	public ActionResult TareasIncompletas(){
		
		return View();
	}


}