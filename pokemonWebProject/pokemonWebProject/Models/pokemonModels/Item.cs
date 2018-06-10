using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Item
    {

        public Item()
        {
            this.Fighters = new HashSet<Fighter>();
        }

        public int itemID { get; set; }

        public string name { get; set; }

        public string effect { get; set; }

        // many to many
        public virtual ICollection<Fighter> Fighters { get; set; }
    }
}