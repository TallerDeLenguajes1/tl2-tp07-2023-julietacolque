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

    [HttpGet("BuscarTarea")]

    public ActionResult<Tarea> BuscarTareaPorId(int id){

        var tarea = manejoTareas.BuscarTporId(id);
        if(tarea!=null)return ok(tarea);
        return  BadRequest();
        
    }

    [HttpGet("ListarTareas")]
    public ActionResult<List<Tarea>> ListarTareas(){
        var lista = manejoTareas.ListarTareas();
        if(lista.Count()!=0)return ok(lista);
        return BadRequest();
    }

    [HttpGet("ListarTareasCompletadas")]

    public ActionResult<List<Tarea>> TareasCompletadas(){
        var listaC = manejoTareas.ListarTareasCompletadas();
        if(listaC.Count()!=0)return ok(listaC);
        return BadRequest();
    }

}
