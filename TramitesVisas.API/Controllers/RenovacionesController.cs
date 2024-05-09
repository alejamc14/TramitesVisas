using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/renovaciones")]

    public class RenovacionesController:ControllerBase
    {
        private readonly DataContext _context;

        public RenovacionesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Renovaciones.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var renovacion = await _context.Renovaciones.FirstOrDefaultAsync(x => x.Id == id);

            if (renovacion == null)
            {
                return NotFound();

            }
            return Ok(renovacion);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Renovacion renovacion)
        {
            _context.Add(renovacion);
            await _context.SaveChangesAsync();
            return Ok(renovacion);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Renovacion renovacion)
        {
            _context.Update(renovacion);
            await _context.SaveChangesAsync();
            return Ok(renovacion);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Renovaciones.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
