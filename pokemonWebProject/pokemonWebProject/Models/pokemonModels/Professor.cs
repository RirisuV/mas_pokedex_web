using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Professor : Person
    {

        public string specialisation { get; set; }

        public int holdedPokemonAmount { get; set; }

        public decimal sallary { get; set; }

    }
}