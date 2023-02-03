using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ProyectoGestionControlVentas.Models;

namespace ProyectoGestionControlVentas.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly VentasAsesoresContext baseDatos;

        public TareaController(VentasAsesoresContext baseDatos)
        {
            this.baseDatos = baseDatos;
        }

    [HttpGet]
    [Route("Lista")]
    public async Task<IActionResult> Lista(){
      var listaTareas = await baseDatos.Tareas.ToListAsync();
      return Ok(listaTareas);
    }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Tarea request)
        {
            await baseDatos.Tareas.AddAsync(request);
            await baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id){
            var tareaEliminar = await baseDatos.Tareas.FindAsync(id);

            if (tareaEliminar == null)
                return BadRequest("No existe la tarea");

            baseDatos.Tareas.Remove(tareaEliminar);
            await baseDatos.SaveChangesAsync();
            return Ok();

        }
        
    }
}
