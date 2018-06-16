using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public abstract class Item
    {

        public int itemID { get; set; }

        public string name { get; set; }

        public string effect { get; set; }

    }
}