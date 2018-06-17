using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Leader
    {
        [Key]
        public int leaderID { get; set; }

        public string specialisation { get; set; }

        public string secondJob { get; set; }

        public decimal sallary { get; set; }


        // one to many
        public ICollection<Challenge> Challenges { get; set; }

        // kompozycja
        public Person Person { get; set; }
        [ForeignKey("Person")]
        public int? PersonID { get; set; }

        // functions

        public Pokemon getLeadPokemon()
        {

            return null;
        }

        public void giveBadgeToTrainer(Trainer trainer)
        {

        }
    }
}