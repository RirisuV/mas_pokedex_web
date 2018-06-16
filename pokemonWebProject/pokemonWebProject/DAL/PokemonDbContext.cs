using pokemonWebProject.Models.pokemonModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pokemonWebProject.DAL
{
    public class PokemonDbContext : DbContext
    {

        public PokemonDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Acquire> Acquires { get; set; }
        public DbSet<BaseStat> BaseStats { get; set; }
        public DbSet<Catched> Catcheds { get; set; }
        public DbSet<Gifted> Gifteds { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Contester> Contesters { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<HeldItem> HeldItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Offensive> Offensives { get; set; }
        public DbSet<OffensiveStatus> GetOffensiveStatuses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonSpecies> PokemonSpecieses { get; set; }
        public DbSet<Professor> Processors { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<PokeType> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



        }

    }
}