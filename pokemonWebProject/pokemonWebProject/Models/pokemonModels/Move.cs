using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Move
    {

        public int moveID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int damageValue { get; set; }

    }
}