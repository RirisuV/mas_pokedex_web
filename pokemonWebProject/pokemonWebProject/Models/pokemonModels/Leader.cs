﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Leader : Person
    {

        public string specialisation { get; set; }

        public string secondJob { get; set; }

        public decimal sallary { get; set; }


        // one to many
        public ICollection<Challenge> Challenges { get; set; }



        // functions

        public Pokemon getLeadPokemon()
        {

            return null;
        }

        public void giveBadgeToTrainer(Trainer trainer)
        {

        }
    }
}