using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using pokemonWebProject.Models.pokemonModels;

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

    }
}