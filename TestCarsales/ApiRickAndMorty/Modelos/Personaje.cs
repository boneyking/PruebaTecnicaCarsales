using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos
{
    public class Personaje : RickYMorty
    {
        public string Status { get; set; }
        public string Gender { get; set; }
        public Origin Origin { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
        public List<string> Episode { get; set; }

        public override string TipoCaptura => nameof(Personaje);
    }
}
