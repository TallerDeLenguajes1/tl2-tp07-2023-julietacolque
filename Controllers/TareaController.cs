using Microsoft.AspNetCore.Mvc;
using  WebApi;

namespace tl2_tp07_2023_julietacolque.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;

       
        ManejoTareas manejoTareas;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
         AccesoADatos accesoDatos = new();
         manejoTareas = new(accesoDatos);
         
        
    

    }

    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea){
        var tareaAux = manejoTareas.AddTarea(tarea);
        return Ok(tareaAux);
    }

}
