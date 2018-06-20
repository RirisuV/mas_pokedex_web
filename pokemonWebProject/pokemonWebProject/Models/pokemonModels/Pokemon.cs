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
        public int PokemonID { get; set; }

        public string Nickname { get; set; }

        public string Gender { get; set; }

        public int Level { get; set; }

        public double Experience { get; set; }

        public int Happiness { get; set; }


        // many to one
        public int CurrentPersonID { get; set; }
        public ApplicationUser CurrentPerson { get; set; }

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
        public int FighterID { get; set; }

        public Contester Contester { get; set; }
        public int ContesterID { get; set; }

        public Acquire Acquire { get; set; }
        public int AcquireID { get; set; }

        // KOMPOZYCJA
        private Pokemon(PokemonSpecies PokemonSpecies, int PokemonID, string Nickname, 
            string Gender, int Level, double Experience, int Happiness)
        {
            this.PokemonID = PokemonID;
            this.Nickname = Nickname;
            this.Gender = Gender;
            this.Level = Level;
            this.Experience = Experience;
            this.Happiness = Happiness;
            this.PokemonSpecies = PokemonSpecies;

        }

        public static Pokemon createPart(PokemonSpecies PokemonSpecies, int PokemonID, string Nickname,
            string Gender, int Level, double Experience, int Happiness)
        {
            if(PokemonSpecies == null)
            {
                throw new Exception("Pokemon Species doesn't exist");
            }

            Pokemon pkmn = new Pokemon(PokemonSpecies, PokemonID, Nickname, Gender, Level, Experience, Happiness);
            PokemonSpecies.addPart(pkmn);

            return pkmn;
        }

        public void addPartFighter(Fighter fighter)
        {
            if (!Fighter.Equals(fighter))
            {
                Fighter = fighter;
            }
        }

        public void addPartContester(Contester contester)
        {
            if (!Contester.Equals(contester))
            {
                Contester = contester;
            }
        }

        public void addPartAcquire(Acquire acquire)
        {
            if (!Acquire.Equals(acquire))
            {
                Acquire = acquire;
            }
        }

        // przeciazenie
        public double getExperience()
        {
            return Experience;
        }

        public double getExperience(int level)
        {
            return Experience * level;
        }


    }
}