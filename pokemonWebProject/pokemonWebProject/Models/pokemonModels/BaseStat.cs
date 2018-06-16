using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class BaseStat
    {

        [Key]
        public int baseStatsID { get; set; }

        public int hpStat { get; set; }

        public int attackStat { get; set; }

        public int defenseStat { get; set; }

        public int specialAttackStat { get; set; }

        public int specialDefenseStat { get; set; }

        public int speedStat { get; set; }

        // one to one
        public int CurrenPokemonSpeciesID { get; set; }
        public PokemonSpecies CurrentPokemonSpecies { get; set; }

        // one to many

    }
}