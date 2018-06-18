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
        public int LeaderID { get; set; }

        public string Specialisation { get; set; }

        public string SecondJob { get; set; }

        public decimal Sallary { get; set; }


        // one to many
        public ICollection<Challenge> Challenges { get; set; }

        // kompozycja
        public Person Person { get; set; }
        public int PersonID { get; set; }

        // dynamic




    }
}