using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRickAndMorty.Modelos
{
    public class Episodio : RickYMorty
    {
        public override string TipoCaptura => nameof(Episodio);
        public string AirDate { get; set; }
        public string Episode { get; set; }
        public List<string> Characters { get; set; }
    }
}
