using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

public class TareaController : Controller
{
    Sistema sistema = Sistema.instancia;



    [HttpGet]
    public IActionResult TareasAPeon()
    {
        ViewBag.ListaPeones = sistema.ListarPeones();
        return View();
    }

    [HttpGet]
    public IActionResult AsignarTarea()
    {
        return View();
    }

    [HttpGet]
    public IActionResult TareasIncompletas(string email)
    {
        ViewBag.ListaTareasSinTerminar = sistema.TareasIncompletas(email);
        return View();
    }





    [HttpPost]
    public IActionResult AsignarTarea(string email, string descripcion, DateTime fechaIngreso, DateTime fechaCierre)
    {
        try
        {
            if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(email)) throw new Exception("Datos nulos, revisar");
            sistema.AltaTarea(email, descripcion, fechaIngreso, fechaCierre);
            ViewBag.Exito = "Tarea creada correctamente";
            return View("AsignarTarea");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("AsignarTarea");
        }
    }

}