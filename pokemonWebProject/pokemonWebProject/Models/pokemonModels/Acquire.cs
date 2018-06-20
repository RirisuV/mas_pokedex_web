using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Acquire
    {

        [Key]
        public int AcquireID { get; set; }

        // kompozycja
        [Required]
        public Pokemon Pokemon { get; set; }
        public int PokemonID { get; set; }

        //public Acquire(Pokemon Pokemon, int AcquireID)
        //{
        //    this.AcquireID = AcquireID;
        //    this.Pokemon = Pokemon;
        //}

        //public static Acquire createPart(Pokemon Pokemon, int AcquireID)
        //{ 
        //    if (Pokemon == null)
        //    {
        //        throw new Exception("Pokemon doesn't exists");
        //    }

        //    Acquire acqPart = new Acquire(Pokemon, AcquireID);

        //    Pokemon.addPartAcquire(acqPart);

        //    return acqPart;
        //}
    }
}