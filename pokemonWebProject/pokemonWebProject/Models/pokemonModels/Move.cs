using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Move
    {

        public int MoveID { get; set; }


        public string name { get; set; }

        public string description { get; set; }

        public int moveDamage { get; set; }

    }
}