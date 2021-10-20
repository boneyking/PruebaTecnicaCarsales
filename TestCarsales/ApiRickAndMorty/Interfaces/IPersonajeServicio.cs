using ApiRickAndMorty.Modelos;
using ApiRickAndMorty.Modelos.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Interfaces
{
    public interface IPersonajeServicio
    {
        Task<(bool resultado, TodosLosPersonajesRespuesta personajeRespuesta, string mensajeError)> ObtenerTodosLosPersonajes();
        Task<(bool resultado, PersonajesPaginadoRespuesta personajesPaginadoRespuesta, string mensajeError)> ObtenerPersonajesPaginado(int pagina);
        Task<(bool resultado, Personaje personaje, string mensajeError)> ObtenerPersonajePorId(int id);
        Task<(bool resultado, List<Personaje> personajes, string mensajeError)> ObtenerMultiplesPersonajesPorId(int[] ids);
    }
}
