using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class PokeType
    {

        public PokeType()
        {
            this.PokemonSpecieses = new HashSet<PokemonSpecies>();
        }

        [Key]
        public int typeID { get; set; }

        public string name { get; set; }

        // many to many
        public virtual ICollection<PokemonSpecies> PokemonSpecieses { get; set; }


    }
}