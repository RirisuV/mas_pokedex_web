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
        public int TrainerID { get; set; }

        public int CatchedPokemonsAmount { get; set; }

        public int DexCompleteAmount { get; set; }

        public decimal Allowance { get; set; }

        // many to many
        public ICollection<Challenge> Challenges { get; set; }

        // one to one
        public License License { get; set; }

        // kompozycja
        [Required]
        public Person Person { get; set; }
        public int PersonID { get; set; }

        // functions

        public int getBadgesAmount()
        {
            return 0;
        }

    }

}