using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class BaseStats
    {

        public int BaseStatsID { get; set; }

        public int hpStat { get; set; }

        public int attackStat { get; set; }

        public int defenseStat { get; set; }

        public int specialAttackStat { get; set; }

        public int specialDefenseStat { get; set; }

        public int speed { get; set; }

    }
}