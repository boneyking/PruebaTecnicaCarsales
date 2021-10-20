using ApiRickAndMorty.Modelos;
using ApiRickAndMorty.Modelos.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Interfaces
{
    public interface ILocalizacionServicio
    {
        Task<(bool resultado, TodasLasLocalizacionesRespuesta localizacionesRespuesta, string mensajeError)> ObtenerTodasLasLocalizaciones();
        Task<(bool resultado, LocalizacionesPaginadoRespuesta localizacionesPaginadoRespuesta, string mensajeError)> ObtenerLocalizacionesPaginado(int pagina);
        Task<(bool resultado, Localizacion localizacion, string mensajeError)> ObtenerLocalizacionPorId(int id);
        Task<(bool resultado, List<Localizacion> localizaciones, string mensajeError)> ObtenerMultiplesLocalizacionesPorId(int[] ids);
    }
}
