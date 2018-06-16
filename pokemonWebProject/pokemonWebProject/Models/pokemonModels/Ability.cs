using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Ability
    {

        public int abilityID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isHidden { get; set; }

        // many to one
        public int CurrentPokemonSpeciesID { get; set; }
        public PokemonSpecies CurrentPokemonSpecies { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }

    }
}