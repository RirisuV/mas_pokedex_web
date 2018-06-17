using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class License
    {

        [Key]
        public int LicenseID { get; set; }

        public decimal LicenseCost { get; set; }

        // one to one
        public Trainer Trainer { get; set; }


    }
}