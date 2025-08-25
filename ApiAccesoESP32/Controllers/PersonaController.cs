using ApiAccesoESP32.Data;
using ApiAccesoESP32.DTOs;
using ApiAccesoESP32.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAccesoESP32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        public readonly AccesoContext _accesoContext;
        public PersonaController(AccesoContext accesoContext)
        {
            _accesoContext = accesoContext;
        }
        [HttpPost("CrearPersona")]
        public async Task<ActionResult> CrearPersona(CrearPersonaDTO personaDTO)
        {
            try
            {
                Persona objPersona = new Persona
                {
                    Nombre = personaDTO.Nombre,
                    Pin = personaDTO.Pin,
                    Uid = personaDTO.Uid,
                };
                _accesoContext.Personas.Add(objPersona);
                await _accesoContext.SaveChangesAsync();
                return Ok($"Persona creada exitosamente {objPersona}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("LeerPersonas")]
        public async Task<ActionResult> ObtenerPersonas()
        {
            try
            {
                List<Persona> listaPersonas = await _accesoContext.Personas.ToListAsync();
                return Ok(listaPersonas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
