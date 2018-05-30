using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class PokemonSpecies
    {


        public int PokemonSpeciesID { get; set; }

        public int number { get; set; }

        public string name { get; set; }

        public string descriptionNo1 { get; set; }

        public string descriptionNo2 { get; set; }

        public string genre { get; set; }

        public byte[] image { get; set; }

    }
}