using ApiRickAndMorty.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeServicio _personajeServicio;

        public PersonajeController(IPersonajeServicio personajeServicio)
        {
            _personajeServicio = personajeServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosPersonajes()
        {
            try
            {
                var resultado = await _personajeServicio.ObtenerTodosLosPersonajes();
                if (resultado.resultado)
                    return Ok(resultado.personajeRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("paginado/{pagina}")]
        public async Task<IActionResult> ObtenerPersonajesPaginado(int pagina = 1)
        {
            try
            {
                var resultado = await _personajeServicio.ObtenerPersonajesPaginado(pagina);
                if (resultado.resultado)
                    return Ok(resultado.personajesPaginadoRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPersonajePorId(int id)
        {
            try
            {
                var resultado = await _personajeServicio.ObtenerPersonajePorId(id);
                if (resultado.resultado)
                    return Ok(resultado.personaje);
                return NotFound(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("multiple")]
        public async Task<IActionResult> ObtenerMultiplesPersonajesPorId([FromQuery] int[] ids)
        {
            try
            {
                var resultado = await _personajeServicio.ObtenerMultiplesPersonajesPorId(ids);
                if (resultado.resultado)
                    return Ok(resultado.personajes);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
