using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TramitesVisas.API.Data;
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

        // Método Get- LISTA
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Personas.ToListAsync());


        }



        // Método Get- por Id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {



            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
            {


                return NotFound();

            }



            return Ok(persona);


        }






        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {

            _context.Add(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);



        }



        // Método actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {

            _context.Update(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);



        }


        //Médoro eliminar registro
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {



            var Filasafectadas = await _context.Personas

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {


                return NotFound();

            }


            return NoContent();

        }
    }
}
