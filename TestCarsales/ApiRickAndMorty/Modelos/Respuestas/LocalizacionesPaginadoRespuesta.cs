using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos.Respuestas
{
    public class LocalizacionesPaginadoRespuesta
    {
        public Info Info { get; set; }
        public List<Localizacion> Results { get; set; }
    }
}
