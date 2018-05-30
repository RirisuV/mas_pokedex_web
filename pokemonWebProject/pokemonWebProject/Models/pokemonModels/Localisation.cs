using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Localisation
    {

        public int localisationID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isCity { get; set; }

    }
}