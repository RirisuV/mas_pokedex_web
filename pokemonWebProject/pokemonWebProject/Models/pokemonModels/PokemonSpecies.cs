using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class PokemonSpecies
    {

        public PokemonSpecies()
        {
            this.SpeciesMoves = new HashSet<Move>();
            this.Types = new HashSet<PokeType>();
            this.Abilities = new HashSet<Ability>();
        }

        [Key]
        public int PokemonSpeciesID { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        // one to one
        public int BaseStatsID { get; set; }
        public BaseStat BaseStats { get; set; }

        // many to many
        public virtual ICollection<Move> SpeciesMoves { get; set; }

        public virtual ICollection<PokeType> Types { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }

        // kompozycja
        public virtual ICollection<Pokemon> Pokemons { get; set; }


        public PokemonSpecies(int PokemonSpeciesID, int Number, string Name, string Description, string Genre)
        {
            this.PokemonSpeciesID = PokemonSpeciesID;
            this.Number = Number;
            this.Name = Name;
            this.Description = Description;
            this.Genre = Genre;
        }

        public void addPart(Pokemon pokemon)
        {
            if (!Pokemons.Contains(pokemon))
            {
                Pokemons.Add(pokemon);
            }
        }

    }
}