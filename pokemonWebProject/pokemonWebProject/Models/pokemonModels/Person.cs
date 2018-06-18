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
        public int PersonID { get; set; }

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Money { get; set; }

        // one to many
        public ICollection<Pokemon> Pokemons { get; set; }

        // kompozycja
        public virtual Trainer Trainer { get; set; }
        
        public virtual Leader Leader { get; set; }

        public virtual Professor Professor { get; set; }

    }
}