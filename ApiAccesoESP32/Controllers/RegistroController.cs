using Microsoft.AspNetCore.Mvc;
using ApiAccesoESP32.models;
using ApiAccesoESP32.Data;
using Microsoft.EntityFrameworkCore;
using ApiAccesoESP32.DTOs;

namespace ApiAccesoESP32.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly AccesoContext _context;

        public RegistroController(AccesoContext context)
        {
            _context = context;
        }

        [HttpPost("CrearRegistro")]
        public async Task<IActionResult> PostRegistro(CrearRegistroDTO registroDTO)
        {
            Registro objRegistro = new Registro
            {
                Uid = registroDTO.Uid,
                Accion = registroDTO.Accion,
                FechaHora = DateTime.UtcNow,
                Metodo = registroDTO.Metodo,
                Nombre = registroDTO.Nombre,
            };
            _context.Registros.Add(objRegistro);
            await _context.SaveChangesAsync();
            return Ok(objRegistro);
        }

        [HttpGet("LeerRegistros")]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistros()
        {
            return await _context.Registros.ToListAsync();
        }

        [HttpGet]
        [Route("VerificarColumnas")]
        public async Task<IActionResult> VerificarColumnas()
        {
            try
            {
                var columnas = await _context.Columnas
                    .FromSqlRaw(
                        @"SELECT column_name AS Column_name
                          FROM information_schema.columns 
                          WHERE table_name = 'registros'")
                    .ToListAsync();

                return Ok(columnas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
