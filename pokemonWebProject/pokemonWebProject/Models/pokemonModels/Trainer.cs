using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Trainer
    {

        public int catchedPokemonsAmount { get; set; }

        public int dexCompleteAmount { get; set; }

        public decimal allowance { get; set; }

        // many to many
        public ICollection<Challenge> Challenges { get; set; }

        // one to one
        public License License { get; set; }
    }

}