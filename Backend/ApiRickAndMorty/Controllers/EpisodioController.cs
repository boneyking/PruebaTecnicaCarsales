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
    public class EpisodioController : ControllerBase
    {
        private readonly IEpisodioServicio _episodioServicio;

        public EpisodioController(IEpisodioServicio episodioServicio)
        {
            _episodioServicio = episodioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosEpisodios()
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerTodosLosEpisodios();
                if (resultado.resultado)
                    return Ok(resultado.episodiosRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerEpisodiosPaginado")]
        public async Task<IActionResult> ObtenerEpisodiosPaginado([FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerEpisodiosPaginado(pagina);
                if (resultado.resultado)
                    return Ok(resultado.episodiosPaginadoRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerEpisodioPorId")]
        public async Task<IActionResult> ObtenerEpisodioPorId([FromQuery] int id)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerEpisodioPorId(id);
                if (resultado.resultado)
                    return Ok(resultado.episodio);
                return NotFound(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerMultiplesEpisodiosPorId")]
        public async Task<IActionResult> ObtenerMultiplesEpisodiosPorId([FromQuery] int[] ids)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerMultiplesEpisodiosPorId(ids);
                if (resultado.resultado)
                    return Ok(resultado.episodios);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
