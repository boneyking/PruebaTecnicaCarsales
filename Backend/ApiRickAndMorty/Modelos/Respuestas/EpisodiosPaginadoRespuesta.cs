using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos.Respuestas
{
    public class EpisodiosPaginadoRespuesta
    {
        public Info Info { get; set; }
        public List<Episodio> Results { get; set; }
    }
}
