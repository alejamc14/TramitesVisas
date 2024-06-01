using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/tiposolicitudes")]
    public class TipoSolicitudesController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoSolicitudesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.TipoVisas.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var tiposolicitud = await _context.TipoVisas.FirstOrDefaultAsync(x => x.Id == id);

            if (tiposolicitud == null)
            {
                return NotFound();

            }
            return Ok(tiposolicitud);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoVisa tiposolicitud)
        {
            _context.Add(tiposolicitud);
            await _context.SaveChangesAsync();
            return Ok(tiposolicitud);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(TipoVisa tiposolicitud)
        {
            _context.Update(tiposolicitud);
            await _context.SaveChangesAsync();
            return Ok(tiposolicitud);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.TipoVisas.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}