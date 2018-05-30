using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required]
        [MaxLength(50)]
        public String firstName { get; set; }

        [Required]
        [MaxLength(50)]
        public String secondName { get; set; }

        [Required]
        [MaxLength(50)]
        public DateTime dateOfBirth { get; set; }

    }
}