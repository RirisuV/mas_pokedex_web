﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Trainer : Person
    {

        public int catchedPokemonsAmount { get; set; }

        public int dexCompleteAmount { get; set; }

        public int allowance { get; set; }

    }

}