using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Pokemon : PokemonSpecies
    {

        public Pokemon()
        {
            this.Moves = new HashSet<Move>();
        }

        [Key]
        public int pokemonID { get; set; }

        public string nickname { get; set; }

        public string gender { get; set; }

        public int level { get; set; }

        public double experience { get; set; }

        public int happiness { get; set; }


        // many to one
        public int CurrentPersonID { get; set; }
        public Person CurrentPerson { get; set; }

        public Ability CurrentAbility { get; set; }
        [ForeignKey("CurrentAbility")]
        public int CurrentAbilityID { get; set; }

        // many to many
        public virtual ICollection<Move> Moves { get; set; }

        // kompozycja
        public PokemonSpecies CurrentPokemonSpecies { get; set; }
        [ForeignKey("PokemonSpecies")]
        public int CurrentPokemonSpeciesID { get; set; }

        private Pokemon(PokemonSpecies CurrentPokemonSpecies, int pokemonID, string nickname, 
            string gender, int level, double experience, int happiness)
        {
            this.pokemonID = pokemonID;
            this.nickname = nickname;
            this.gender = gender;
            this.level = level;
            this.experience = experience;
            this.happiness = happiness;
            this.CurrentPokemonSpecies = CurrentPokemonSpecies;

        }

        public static Pokemon createPart(PokemonSpecies CurrentPokemonSpecies, int pokemonID, string nickname,
            string gender, int level, double experience, int happiness)
        {
            if(CurrentPokemonSpecies == null)
            {
                throw new Exception("Pokemon Species doesn't exist");
            }

            Pokemon pkmn = new Pokemon(CurrentPokemonSpecies, pokemonID, nickname, gender, level, experience, happiness);
            CurrentPokemonSpecies.addPart(pkmn);

            return pkmn;
        }

        // resharper jetbrain

    }
}