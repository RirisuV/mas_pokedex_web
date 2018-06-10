using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Trainer : Person
    {

        public Trainer()
        {
            this.Badges = new HashSet<Badge>();
        }

        public int catchedPokemonsAmount { get; set; }

        public int dexCompleteAmount { get; set; }

        public decimal allowance { get; set; }

        // many to many
        public virtual ICollection<Badge> Badges { get; set; }

    }

}