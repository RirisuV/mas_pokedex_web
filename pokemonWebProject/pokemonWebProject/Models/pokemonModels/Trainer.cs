using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Trainer : Person
    {

        public int money { get; set; }

        public int pokemonAmount { get; set; }

        public int pokemonsScanned { get; set; }

    }

}