﻿using Microsoft.AspNetCore.Mvc;
using TramitesVisas.API.Data;
using TramitesVisas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TramitesVisas.API.Controllers
{
    [ApiController]
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
        public async Task<ActionResult> PutAsync(Solicitud solicitud)
        {
            _context.Update(solicitud);
            await _context.SaveChangesAsync();
            return Ok(solicitud);

        }

        //Médoro eliminar registro
        [HttpDelete("{id:int}")]
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
