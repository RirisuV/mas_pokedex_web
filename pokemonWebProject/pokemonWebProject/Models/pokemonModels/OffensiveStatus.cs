using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class OffensiveStatus : Status, IOffensive 
    {

        public bool isContact { get; set; }

        public string category { get; set; }

        public int basicDamage { get; set; }

    }
}