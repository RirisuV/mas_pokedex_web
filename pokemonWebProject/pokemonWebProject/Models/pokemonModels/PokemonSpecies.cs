using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class PokemonSpecies
    {

        public PokemonSpecies()
        {
            this.SpeciesMoves = new HashSet<Move>();
            this.Types = new HashSet<PokeType>();
        }

        public int pokemonSpeciesID { get; set; }

        public int number { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string genre { get; set; }

        public byte[] image { get; set; }

        // one to one
        public int CurrentBaseStatsID { get; set; }
        public BaseStat CurrentBaseStats { get; set; }

        // one to many
        public Ability Abilities { get; set; }

        // many to many
        public virtual ICollection<Move> SpeciesMoves { get; set; }
        public virtual ICollection<PokeType> Types { get; set; }

    }
}