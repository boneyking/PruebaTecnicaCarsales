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
    public class PersonajeServicio : IPersonajeServicio
    {
        private readonly ILogger<PersonajeServicio> _logger;
        private readonly IHttpClientFactory _httpClient;

        public PersonajeServicio(ILogger<PersonajeServicio> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<(bool resultado, List<Personaje> personajes, string mensajeError)> ObtenerMultiplesPersonajesPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyApi");

                var idsConcatenados = string.Join(",", ids);
                
                var respuesta = await cliente.GetAsync($"api/character/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Personaje>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, Personaje personaje, string mensajeError)> ObtenerPersonajePorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyApi");
                var respuesta = await cliente.GetAsync($"api/character/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Personaje>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, PersonajesPaginadoRespuesta personajesPaginadoRespuesta, string mensajeError)> ObtenerPersonajesPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyApi");
                var respuesta = await cliente.GetAsync($"api/character/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<PersonajesPaginadoRespuesta>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, TodosLosPersonajesRespuesta personajeRespuesta, string mensajeError)> ObtenerTodosLosPersonajes()
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyApi");
                var respuesta = await cliente.GetAsync("api/character");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<TodosLosPersonajesRespuesta>(contenido, opciones);

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
