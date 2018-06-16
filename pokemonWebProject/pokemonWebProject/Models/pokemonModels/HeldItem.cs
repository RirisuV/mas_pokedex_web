using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class HeldItems : Item
    {

        public bool canDrop { get; set; }

        // many to one
        public ICollection<Fighter> Fighters { get; set; }

    }
}