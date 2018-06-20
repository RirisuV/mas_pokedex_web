using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class HeldItem : Item
    {

        public bool CanDrop { get; set; }

        // many to one
        public ICollection<Fighter> Fighters { get; set; }

        public HeldItem(int ItemID, string Name, string Effect, bool CanDrop) 
            : base(ItemID, Name, Effect)
        {
            this.CanDrop = CanDrop;
        }

        public override string getFullDesc()
        {
            return Effect + " | Przedmiotu " + CanDrop + " można upuścić";
        }
    }
}