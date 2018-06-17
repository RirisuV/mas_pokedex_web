using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Pokemon 
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
        [Required]
        public PokemonSpecies PokemonSpecies { get; set; }
        [ForeignKey("PokemonSpecies")]
        public int PokemonSpeciesID { get; set; }

        public Fighter Fighter { get; set; }
        public int? FighterID { get; set; }

        public Contester Contester { get; set; }
        public int ContesterID { get; set; }

        public Acquire Acquire { get; set; }
        public int AcquireID { get; set; }


        private Pokemon(PokemonSpecies PokemonSpecies, int pokemonID, string nickname, 
            string gender, int level, double experience, int happiness)
        {
            this.pokemonID = pokemonID;
            this.nickname = nickname;
            this.gender = gender;
            this.level = level;
            this.experience = experience;
            this.happiness = happiness;
            this.PokemonSpecies = PokemonSpecies;

        }

        public static Pokemon createPart(PokemonSpecies PokemonSpecies, int pokemonID, string nickname,
            string gender, int level, double experience, int happiness)
        {
            if(PokemonSpecies == null)
            {
                throw new Exception("Pokemon Species doesn't exist");
            }

            Pokemon pkmn = new Pokemon(PokemonSpecies, pokemonID, nickname, gender, level, experience, happiness);
            PokemonSpecies.addPart(pkmn);

            return pkmn;
        }

        // resharper jetbrain

    }
}