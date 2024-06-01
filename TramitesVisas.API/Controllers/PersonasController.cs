using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Personas.ToListAsync());

        }


        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
            {
                return NotFound();

            }
            return Ok(persona);

        }

        // Método Get- por Id
        [HttpGet("user/{cedula}")]
        public async Task<ActionResult> GetDocumentAsync(string cedula)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Documento.Equals(cedula));

            if (persona == null)
            {
                return NotFound();

            }
            return Ok(persona);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Persona persona)
        {
            _context.Update(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Personas.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
