using ApiRickAndMorty.Modelos;
using ApiRickAndMorty.Modelos.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Interfaces
{
    public interface IEpisodioServicio
    {
        Task<(bool resultado, TodosLosEpisodiosRespuesta episodiosRespuesta, string mensajeError)> ObtenerTodosLosEpisodios();
        Task<(bool resultado, EpisodiosPaginadoRespuesta episodiosPaginadoRespuesta, string mensajeError)> ObtenerEpisodiosPaginado(int pagina);
        Task<(bool resultado, Episodio episodio, string mensajeError)> ObtenerEpisodioPorId(int id);
        Task<(bool resultado, List<Episodio> episodios, string mensajeError)> ObtenerMultiplesEpisodiosPorId(int[] ids);
    }
}
