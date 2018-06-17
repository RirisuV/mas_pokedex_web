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
        public int pokemonSpeciesID { get; set; }

        public int number { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string genre { get; set; }

        // one to one
        public int CurrentBaseStatsID { get; set; }
        public BaseStat CurrentBaseStats { get; set; }

        // many to many
        public virtual ICollection<Move> SpeciesMoves { get; set; }

        public virtual ICollection<PokeType> Types { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }

        // kompozycja
        public virtual ICollection<Pokemon> Pokemons { get; set; }


        public PokemonSpecies(int pokemonSpeciesID, int number, string name, string description, string genre)
        {
            this.pokemonSpeciesID = pokemonSpeciesID;
            this.number = number;
            this.name = name;
            this.description = description;
            this.genre = genre;
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