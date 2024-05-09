using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/gerentes")]
    public class GerentesController : ControllerBase
    {
        private readonly DataContext _context;

        public GerentesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Gerentes.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var gerente = await _context.Gerentes.FirstOrDefaultAsync(x => x.Id == id);

            if (gerente == null)
            {
                return NotFound();

            }
            return Ok(gerente);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Gerente gerente)
        {
            _context.Add(gerente);
            await _context.SaveChangesAsync();
            return Ok(gerente);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Gerente gerente)
        {
            _context.Update(gerente);
            await _context.SaveChangesAsync();
            return Ok(gerente);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Gerentes.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
