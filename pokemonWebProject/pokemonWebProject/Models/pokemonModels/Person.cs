using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using pokemonWebProject.Models.pokemonModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Person
    {
        [Key]
        public int personID { get; set; }

        public String firstName { get; set; }

        public String secondName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public decimal money { get; set; }

        // one to many
        public ICollection<Pokemon> Pokemons { get; set; }

        // kompozycja
        public Trainer Trainer { get; set; }
        public int? TrainerID { get; set; }

        public Leader Leader { get; set; }
        public int? LeaderID { get; set; }

        public Professor Professor { get; set; }
        public int? ProfessorID { get; set; }


    }
}