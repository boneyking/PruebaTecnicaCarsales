﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos.Respuestas
{
    public class PersonajesPaginadoRespuesta
    {
        public Info Info { get; set; }
        public List<Personaje> Results { get; set; }
    }
}
