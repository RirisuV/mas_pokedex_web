using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Pokemon : PokemonSpecies
    {

        public string nickname { get; set; }

        public string gender { get; set; }

        public int level { get; set; }

        public double experience { get; set; }

        public int happiness { get; set; }

        // many to one
        public ICollection<Person> Pokemons { get; set; }

    }
}