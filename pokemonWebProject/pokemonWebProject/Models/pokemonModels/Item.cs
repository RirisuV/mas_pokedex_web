using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public abstract class Item
    {

        [Key]
        public int itemID { get; set; }

        public string name { get; set; }

        public string effect { get; set; }

    }
}