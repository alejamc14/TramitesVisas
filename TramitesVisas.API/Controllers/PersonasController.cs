using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
using TramitesVisas.API.Helpers;
using TramitesVisas.Shared.DTOs;
using TramitesVisas.Shared.Entidades;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
    [Route("/api/personas")]
    public class PersonasController: ControllerBase
    {
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        ////para paginar y filtro
        //[HttpGet]
        //public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        //{
        //    var queryable = _context.Personas
        //     .AsQueryable();
        //    if (!string.IsNullOrWhiteSpace(pagination.Filter))
        //    {
        //        queryable = queryable.Where(x => x.NombreCompleto.ToLower().Contains(pagination.Filter.ToLower()));
        //    }
        //    return Ok(await queryable
        //    .OrderBy(x => x.NombreCompleto)
        //    .Paginate(pagination)
        //    .ToListAsync());
        //}

        //[HttpGet("totalPages")]
        //public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)

        //{
        //    var queryable = _context.Personas.AsQueryable();
        //    if (!string.IsNullOrWhiteSpace(pagination.Filter))
        //    {
        //        queryable = queryable.Where(x => x.NombreCompleto.ToLower().Contains(pagination.Filter.ToLower()));
        //    }
        //    double count = await queryable.CountAsync();
        //    double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
        //    return Ok(totalPages);
        //}

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
