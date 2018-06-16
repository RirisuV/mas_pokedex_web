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

        public int CurrentAbilityID { get; set; }
        [ForeignKey("CurrentAbilityID")]
        public Ability CurrentAbility { get; set; }

        // many to many
        public virtual ICollection<Move> Moves { get; set; }
    }
}