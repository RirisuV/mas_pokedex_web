﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Fighter : Pokemon
    {

        public int fighterID { get; set; }

        public int hpEvTrained { get; set; }

        public int attackEvTrained { get; set; }

        public int defenseEvTrained { get; set; }

        public int specialAttackEvTrained { get; set; }

        public int specialDefenseEvTrained { get; set; }

        public int speedEvTrained { get; set; }

        // one to many
        public int CurrentHeldItemID { get; set; }
        public HeldItem CurrentHeldItem { get; set; }

        // kompozycja
        [Required]
        public Pokemon Pokemon { get; set; }
        public int PokemonID { get; set; }

    }
}