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
        public int MoveID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DamageValue { get; set; }

        // many to many
        public virtual ICollection<PokemonSpecies> PokemonSpecieses { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; }

    }
}