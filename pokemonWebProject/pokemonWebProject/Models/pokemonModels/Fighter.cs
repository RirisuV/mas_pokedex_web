using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Fighter
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


        private Fighter(Pokemon Pokemon, int FighterID, 
            int HpEvTrained, int AttackEvTrained, int DefenseEvTrained,
            int SpecialAttackEvTrained, int SpecialDefenseEvTrained, int SpeedEvTrained)
        {          
            this.FighterID = FighterID;
            this.FighterID = FighterID;
            this.HpEvTrained = HpEvTrained;
            this.AttackEvTrained = AttackEvTrained;
            this.DefenseEvTrained = DefenseEvTrained;
            this.SpecialAttackEvTrained = SpecialAttackEvTrained;
            this.SpecialDefenseEvTrained = SpecialDefenseEvTrained;
            this.SpeedEvTrained = SpeedEvTrained;
            this.Pokemon = Pokemon;
        }

        public static Fighter createPart(Pokemon Pokemon, int FighterID,
            int HpEvTrained, int AttackEvTrained, int DefenseEvTrained,
            int SpecialAttackEvTrained, int SpecialDefenseEvTrained, int SpeedEvTrained)
        {
            if(Pokemon == null)
            {
                throw new Exception("Pokemon doesn't exists");
            }

            Fighter fighPart = new Fighter(Pokemon, FighterID, HpEvTrained, AttackEvTrained, 
                DefenseEvTrained, SpecialAttackEvTrained, 
                SpecialDefenseEvTrained, SpeedEvTrained);

            Pokemon.addPartFighter(fighPart);

            return fighPart;  
        }

    }
}