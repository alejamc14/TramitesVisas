using Microsoft.AspNetCore.Mvc;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/solicitudes")]
    public class SolicitudesController:ControllerBase
    {
        private readonly DataContext _context;

        public SolicitudesController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Solicitudes.ToListAsync());

        }

        [HttpGet("Persona/{id:int}")]
        public async Task<ActionResult> GetPersonaAsync(int id)
        {
            return Ok(await _context.Solicitudes.Where(x => x.PersonaId == id).ToListAsync());

        }

        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var solicitud = await _context.Solicitudes.FirstOrDefaultAsync(x => x.Id == id);

            if (solicitud == null)
            {
                return NotFound();

            }
            return Ok(solicitud);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Solicitud solicitud)
        {
            if(solicitud.Estado == null)
            {
                solicitud.Estado = "Pendiente";
            }
            _context.Add(solicitud);
            await _context.SaveChangesAsync();
            return Ok(solicitud);

        }


        // Método actualizar
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PutAsync(Solicitud solicitud)
        {
            _context.Update(solicitud);
            await _context.SaveChangesAsync();
            return Ok(solicitud);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Solicitudes.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
