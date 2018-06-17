using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Professor
    {
        [Key]
        public int professorID { get; set; }

        public string specialisation { get; set; }

        public int holdedPokemonAmount { get; set; }

        public decimal sallary { get; set; }


        // kompozycja
        [Required]
        public Person Person { get; set; }
        public int PersonID { get; set; }

    }
}