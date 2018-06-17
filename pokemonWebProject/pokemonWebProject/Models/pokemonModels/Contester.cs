using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Contester
    {

        public int contesterID { get; set; }

        public string specialisation { get; set; }

        // kompozycja
        public Pokemon Pokemon { get; set; }
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }

    }
}