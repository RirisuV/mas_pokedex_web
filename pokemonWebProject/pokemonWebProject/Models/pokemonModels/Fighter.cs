using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Fighter : Pokemon
    {
        public Fighter()
        {
            this.Items = new HashSet<Item>();
        }

        public int hpEvTrained { get; set; }

        public int attackEvTrained { get; set; }

        public int defenseEvTrained { get; set; }

        public int specialAttackEvTrained { get; set; }

        public int specialDefenseEvTrained { get; set; }

        public int speedEvTrained { get; set; }

        // many to many
        public virtual ICollection<Item> Items { get; set; }

    }
}