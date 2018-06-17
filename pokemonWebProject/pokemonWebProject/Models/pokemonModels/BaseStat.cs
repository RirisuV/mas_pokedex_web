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
        public int BaseStatsID { get; set; }

        public int HpStat { get; set; }

        public int AttackStat { get; set; }

        public int DefenseStat { get; set; }

        public int SpecialAttackStat { get; set; }

        public int SpecialDefenseStat { get; set; }

        public int SpeedStat { get; set; }

        // one to one
        public int PokemonSpeciesID { get; set; }
        public PokemonSpecies PokemonSpecies { get; set; }

        // one to many

    }
}