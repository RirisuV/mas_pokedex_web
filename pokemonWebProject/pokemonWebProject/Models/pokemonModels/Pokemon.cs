using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Pokemon : PokemonSpecies
    {

        public string Nickname { get; set; }

        public string Gender { get; set; }

        public int Level { get; set; }

        public double Experience { get; set; }

        public int Happiness { get; set; }

    }
}