using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class License
    {

        public int licenseID { get; set; }

        public decimal licenseCost { get; set; }


        // one to one
        public Trainer CurrentTrainer { get; set; }
        public int CurrentTrainerID { get; set; }


    }
}