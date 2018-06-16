using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using pokemonWebProject.Models.pokemonModels;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Person
    {
        [Key]
        [Required]
        public int personID { get; set; }

        [Required]
        [MaxLength(50)]
        public String firstName { get; set; }

        [Required]
        [MaxLength(50)]
        public String secondName { get; set; }

        [Required]
        [MaxLength(50)]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public decimal money { get; set; }

        // one to many
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}