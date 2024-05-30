using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;
using System.Threading.Tasks;
using System.Linq;
namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/visas")]
    public class VisasController: ControllerBase
    {

        private readonly DataContext _context;

        public VisasController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Visas.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var visa = await _context.Visas.FirstOrDefaultAsync(x => x.Id == id);

            if (visa == null)
            {
                return NotFound();

            }
            return Ok(visa);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Documento visa)
        {
            _context.Add(visa);
            await _context.SaveChangesAsync();
            return Ok(visa);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Documento visa)
        {
            _context.Update(visa);
            await _context.SaveChangesAsync();
            return Ok(visa);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Visas.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
