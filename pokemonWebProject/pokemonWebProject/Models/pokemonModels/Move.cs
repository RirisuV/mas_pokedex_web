using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Move
    {

        public Move()
        {
            this.PokemonSpecieses = new HashSet<PokemonSpecies>();
            this.Pokemons = new HashSet<Pokemon>();
        }

        [Key]
        public int moveID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int damageValue { get; set; }

        // many to many
        public virtual ICollection<PokemonSpecies> PokemonSpecieses { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; }

    }
}