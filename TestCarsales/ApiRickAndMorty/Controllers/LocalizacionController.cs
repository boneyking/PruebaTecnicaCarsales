using ApiRickAndMorty.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionController : ControllerBase
    {
        private readonly ILocalizacionServicio _localizacionServicio;

        public LocalizacionController(ILocalizacionServicio localizacionServicio)
        {
            _localizacionServicio = localizacionServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasLocalizaciones()
        {
            try
            {
                var resultado = await _localizacionServicio.ObtenerTodasLasLocalizaciones();
                if (resultado.resultado)
                    return Ok(resultado.localizacionesRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("paginado/{pagina}")]
        public async Task<IActionResult> ObtenerLocalizacionesPaginado(int pagina = 1)
        {
            try
            {
                var resultado = await _localizacionServicio.ObtenerLocalizacionesPaginado(pagina);
                if (resultado.resultado)
                    return Ok(resultado.localizacionesPaginadoRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerLocalizacionPorId(int id)
        {
            try
            {
                var resultado = await _localizacionServicio.ObtenerLocalizacionPorId(id);
                if (resultado.resultado)
                    return Ok(resultado.localizacion);
                return NotFound(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("multiple")]
        public async Task<IActionResult> ObtenerMultiplesLocalizacionesPorId([FromQuery] int[] ids)
        {
            try
            {
                var resultado = await _localizacionServicio.ObtenerMultiplesLocalizacionesPorId(ids);
                if (resultado.resultado)
                    return Ok(resultado.localizaciones);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
