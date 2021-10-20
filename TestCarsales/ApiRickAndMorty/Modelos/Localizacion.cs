using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos
{
    public class Localizacion : RickYMorty
    {
        public string Dimension { get; set; }
        public List<string> Residents { get; set; }
        public override string TipoCaptura => nameof(Localizacion);
    }
}
