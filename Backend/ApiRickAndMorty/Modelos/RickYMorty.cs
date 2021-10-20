using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos
{
    public abstract class RickYMorty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public abstract string TipoCaptura { get; }
    }
}
