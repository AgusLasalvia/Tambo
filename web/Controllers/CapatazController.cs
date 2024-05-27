using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class CapatazController : Controller
{
	Sistema sistema = Sistema.instancia;


	private readonly ILogger<CapatazController> _logger;

	public CapatazController(ILogger<CapatazController> logger)
	{

		_logger = logger;
	}
}