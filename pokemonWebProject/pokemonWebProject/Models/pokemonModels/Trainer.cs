using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Trainer
    {

        [Key]
        public int trainerID { get; set; }

        public int catchedPokemonsAmount { get; set; }

        public int dexCompleteAmount { get; set; }

        public decimal allowance { get; set; }

        // many to many
        public ICollection<Challenge> Challenges { get; set; }

        // one to one
        public License License { get; set; }

        // kompozycja
        public Person Person { get; set; }
        [ForeignKey("Person")]
        public int PersonID { get; set; }

        // functions

        public int getBadgesAmount()
        {
            return 0;
        }

    }

}