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
    [Route("/api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly DataContext _context;

        public PagosController(DataContext context)
        {
            _context = context;
        }

        // Método Get- Lista
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Pagos.ToListAsync());

        }

       

        // Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var pago = await _context.Pagos.FirstOrDefaultAsync(x => x.Id == id);

            if (pago == null)
            {
                return NotFound();

            }
            return Ok(pago);

        }


        //Metodo para Crear 
        [HttpPost]
        public async Task<ActionResult> PostAsync(Pago pago)
        {
            _context.Add(pago);
            await _context.SaveChangesAsync();
            return Ok(pago);

        }



        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> PutAsync(Pago pago)
        {
            _context.Update(pago);
            await _context.SaveChangesAsync();
            return Ok(pago);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deletedrows = await _context.Pagos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (deletedrows == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
