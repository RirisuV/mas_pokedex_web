using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Fighter : Pokemon
    {

        public int FighterID { get; set; }

        public int HpEvTrained { get; set; }

        public int AttackEvTrained { get; set; }

        public int DefenseEvTrained { get; set; }

        public int SpecialAttackEvTrained { get; set; }

        public int SpecialDefenseEvTrained { get; set; }

        public int SpeedEvTrained { get; set; }

        // one to many
        public int CurrentHeldItemID { get; set; }
        public HeldItem CurrentHeldItem { get; set; }

        // kompozycja
        [Required]
        public Pokemon Pokemon { get; set; }
        public int PokemonID { get; set; }

    }
}