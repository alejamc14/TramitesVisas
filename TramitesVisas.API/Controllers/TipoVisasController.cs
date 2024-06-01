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
    [Route("/api/tipovisas")]
    public class TipoVisasController:ControllerBase
    {
        private readonly DataContext _context;

        public TipoVisasController(DataContext context)
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
            var tipovisa = await _context.TipoVisas.FirstOrDefaultAsync(x => x.Id == id);

            if (tipovisa == null)
            {
                return NotFound();

            }
            return Ok(tipovisa);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoVisa tipovisa)
        {
            _context.Add(tipovisa);
            await _context.SaveChangesAsync();
            return Ok(tipovisa);

        }


        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(TipoVisa tipovisa)
        {
            _context.Update(tipovisa);
            await _context.SaveChangesAsync();
            return Ok(tipovisa);

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
