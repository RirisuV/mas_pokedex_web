using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Catched : Pokemon
    {

        public string catchedLocation { get; set; }

        public string usedBall { get; set; }

    }
}