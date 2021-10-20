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
    public class LocalizacionServicio : ILocalizacionServicio
    {
        private readonly ILogger<LocalizacionServicio> _logger;
        private readonly IHttpClientFactory _httpClient;

        public LocalizacionServicio(ILogger<LocalizacionServicio> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<(bool resultado, LocalizacionesPaginadoRespuesta localizacionesPaginadoRespuesta, string mensajeError)> ObtenerLocalizacionesPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync($"api/location/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<LocalizacionesPaginadoRespuesta>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, Localizacion localizacion, string mensajeError)> ObtenerLocalizacionPorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync($"api/location/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Localizacion>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, List<Localizacion> localizaciones, string mensajeError)> ObtenerMultiplesLocalizacionesPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");

                var idsConcatenados = string.Join(",", ids);

                var respuesta = await cliente.GetAsync($"api/location/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Localizacion>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, TodasLasLocalizacionesRespuesta localizacionesRespuesta, string mensajeError)> ObtenerTodasLasLocalizaciones()
        {
            try
            {
                var cliente = _httpClient.CreateClient("ApiRickAndMorty");
                var respuesta = await cliente.GetAsync("api/location");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<TodasLasLocalizacionesRespuesta>(contenido, opciones);

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
