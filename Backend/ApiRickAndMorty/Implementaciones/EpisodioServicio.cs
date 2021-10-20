using ApiRickAndMorty.Interfaces;
using ApiRickAndMorty.Modelos;
using ApiRickAndMorty.Modelos.Respuestas;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Implementaciones
{
    public class EpisodioServicio : IEpisodioServicio
    {
        private readonly ILogger<EpisodioServicio> _logger;
        private readonly IHttpClientFactory _httpClient;

        public EpisodioServicio(ILogger<EpisodioServicio> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<(bool resultado, Episodio episodio, string mensajeError)> ObtenerEpisodioPorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync($"api/episode/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Episodio>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, EpisodiosPaginadoRespuesta episodiosPaginadoRespuesta, string mensajeError)> ObtenerEpisodiosPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync($"api/episode/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<EpisodiosPaginadoRespuesta>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, List<Episodio> episodios, string mensajeError)> ObtenerMultiplesEpisodiosPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");

                var idsConcatenados = string.Join(",", ids);

                var respuesta = await cliente.GetAsync($"api/episode/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Episodio>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, TodosLosEpisodiosRespuesta episodiosRespuesta, string mensajeError)> ObtenerTodosLosEpisodios()
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync("api/episode");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<TodosLosEpisodiosRespuesta>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
