﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public abstract class Item
    {

        [Key]
        public int ItemID { get; set; }

        public string Name { get; set; }

        public string Effect { get; set; }

        public Item(int ItemID, string Name, string Effect) 
            : base()
        {

            this.ItemID = ItemID;
            this.Name = Name;
            this.Effect = Effect;
        }

        public abstract String getFullDesc();

    }
}