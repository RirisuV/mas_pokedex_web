using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Contester
    {

        public int ContesterID { get; set; }

        public string Specialisation { get; set; }

        // kompozycja
        [Required]
        public Pokemon Pokemon { get; set; }
        public int PokemonID { get; set; }


        public Contester(Pokemon Pokemon, int ContesterID, string Specialisation)
        {
            this.ContesterID = ContesterID;
            this.Specialisation = Specialisation;
            this.Pokemon = Pokemon;
        }

        public static Contester createPart(Pokemon Pokemon, int ContesterID, string Specialisation)
        {
            if (Pokemon == null)
            {
                throw new Exception("Pokemon doesn't exists");
            }

            Contester contPart = new Contester(Pokemon, ContesterID, Specialisation);

            Pokemon.addPartContester(contPart);

            return contPart;
        }

    }
}