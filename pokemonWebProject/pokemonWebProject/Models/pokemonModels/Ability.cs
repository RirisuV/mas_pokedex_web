using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Ability
    {

        public Ability()
        {
            this.PokemonSpecieses = new HashSet<PokemonSpecies>();
        }

        [Key]
        public int abilityID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isHidden { get; set; }

        // many to many
        public virtual ICollection<PokemonSpecies> PokemonSpecieses { get; set; }

        // one to many
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}