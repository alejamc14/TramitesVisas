using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;
using System.Threading.Tasks;
using System.Linq;


namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/documentos")]
    public class DocumentosController : ControllerBase
    {
        private readonly DataContext _context;

        public DocumentosController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Documentos.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var documento = await _context.Documentos.FirstOrDefaultAsync(x => x.Id == id);

            if (documento == null)
            {
                return NotFound();

            }
            return Ok(documento);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Documento documento)
        {
            _context.Add(documento);
            await _context.SaveChangesAsync();
            return Ok(documento);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Documento documento)
        {
            _context.Update(documento);
            await _context.SaveChangesAsync();
            return Ok(documento);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Documentos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
