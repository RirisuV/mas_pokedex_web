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
        public int ProfessorID { get; set; }

        public string Specialisation { get; set; }

        public int HoldedPokemonAmount { get; set; }

        public decimal Sallary { get; set; }


        // kompozycja
        public Person Person { get; set; }
        public int PersonID { get; set; }


    }
}