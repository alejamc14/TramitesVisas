using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/historiales")]
    public class HistorialesController : ControllerBase
    {
        private readonly DataContext _context;

        public HistorialesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Historiales.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var historial = await _context.Historiales.FirstOrDefaultAsync(x => x.Id == id);

            if (historial == null)
            {
                return NotFound();

            }
            return Ok(historial);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Historial historial)
        {
            _context.Add(historial);
            await _context.SaveChangesAsync();
            return Ok(historial);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Historial historial)
        {
            _context.Update(historial);
            await _context.SaveChangesAsync();
            return Ok(historial);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Historiales.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
