using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class PokemonSpecies
    {

        public int pokemonSpeciesID { get; set; }

        public int number { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string genre { get; set; }

        public byte[] image { get; set; }

        // STATS

        public int hpStat { get; set; }

        public int attackStat { get; set; }

        public int defenseStat { get; set; }

        public int specialAttackStat { get; set; }

        public int specialDefenseStat { get; set; }

        public int speedStat { get; set; }

    }
}