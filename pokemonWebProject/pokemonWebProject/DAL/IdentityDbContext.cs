using Microsoft.AspNet.Identity.EntityFramework;
using pokemonWebProject.Models;
using pokemonWebProject.Models.pokemonModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace pokemonWebProject.DAL
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {

        public IdentityDbContext()
            : base("DefaultConnection")
        {

        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
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
        public DbSet<Person> People { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonSpecies> PokemonSpecieses { get; set; }
        public DbSet<Professor> Processors { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<PokeType> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* ONE TO ONE */
            // Trainer-License
            modelBuilder.Entity<Trainer>()
                .HasRequired(s => s.License)
                .WithRequiredPrincipal(ad => ad.Trainer);

            // PokemonSpecies-BaseStat
            modelBuilder.Entity<PokemonSpecies>()
                .HasRequired(s => s.BaseStats)
                .WithRequiredPrincipal(ad => ad.PokemonSpecies);


            /* ONE TO MANY */
            // Person-Pokemon
            modelBuilder.Entity<Pokemon>()
                .HasRequired<Person>(s => s.CurrentPerson)
                .WithMany(g => g.Pokemons)
                .HasForeignKey<int>(s => s.CurrentPersonID);

            // Leader-Challenge
            modelBuilder.Entity<Challenge>()
                .HasRequired<Leader>(s => s.CurrentLeader)
                .WithMany(g => g.Challenges)
                .HasForeignKey<int>(s => s.CurrentLeaderID)
                .WillCascadeOnDelete(false);

            // Trainer-Challenge
            modelBuilder.Entity<Challenge>()
                .HasRequired<Trainer>(s => s.CurrentTrainer)
                .WithMany(g => g.Challenges)
                .HasForeignKey<int>(s => s.CurrentTrainerID)
                .WillCascadeOnDelete(false);

            // Ability-Pokemon
            modelBuilder.Entity<Pokemon>()
                .HasRequired<Ability>(s => s.CurrentAbility)
                .WithMany(g => g.Pokemons)
                .HasForeignKey<int>(s => s.CurrentAbilityID);

            // HeldItem-Fighter
            modelBuilder.Entity<Fighter>()
                .HasRequired<HeldItem>(s => s.CurrentHeldItem)
                .WithMany(g => g.Fighters)
                .HasForeignKey<int>(s => s.CurrentHeldItemID);


            /* MANY TO MANY */
            // Pokemon-Move
            modelBuilder.Entity<Pokemon>()
                .HasMany<Move>(s => s.Moves)
                .WithMany(c => c.Pokemons)
                .Map(cs =>
                {
                    cs.MapLeftKey("PokemonRefId");
                    cs.MapRightKey("MoveRefId");
                    cs.ToTable("PokemonMove");
                });

            // PokemonSpecies-PokeType
            modelBuilder.Entity<PokemonSpecies>()
               .HasMany<PokeType>(s => s.Types)
               .WithMany(c => c.PokemonSpecieses)
               .Map(cs =>
               {
                   cs.MapLeftKey("PokemonSpeciesRefId");
                   cs.MapRightKey("TypeRefId");
                   cs.ToTable("PokemonspeciesType");
               });

            // PokemonSpecies-Ability
            modelBuilder.Entity<PokemonSpecies>()
               .HasMany<Ability>(s => s.Abilities)
               .WithMany(c => c.PokemonSpecieses)
               .Map(cs =>
               {
                   cs.MapLeftKey("PokemonSpeciesRefId");
                   cs.MapRightKey("AbilityRefId");
                   cs.ToTable("PokemonspeciesAbility");
               });

            // PokemonSpecies-Moves
            modelBuilder.Entity<PokemonSpecies>()
               .HasMany<Move>(s => s.SpeciesMoves)
               .WithMany(c => c.PokemonSpecieses)
               .Map(cs =>
               {
                   cs.MapLeftKey("PokemonSpeciesRefId");
                   cs.MapRightKey("MoveRefId");
                   cs.ToTable("PokemonspeciesMove");
               });

            /* KOMPOZYCJA */
            // PokemonSpecies-Pokemon
            modelBuilder.Entity<Pokemon>()
                .HasRequired<PokemonSpecies>(s => s.PokemonSpecies)
                .WithMany(g => g.Pokemons)
                .HasForeignKey<int>(s => s.PokemonSpeciesID);

            modelBuilder.Entity<Pokemon>()
                .HasRequired(s => s.Fighter)
                .WithRequiredPrincipal(ad => ad.Pokemon);

            modelBuilder.Entity<Pokemon>()
                .HasRequired(s => s.Contester)
                .WithRequiredPrincipal(ad => ad.Pokemon);

            modelBuilder.Entity<Person>()
                .HasRequired(s => s.Trainer)
                .WithOptional(ad => ad.Person);

            modelBuilder.Entity<Person>()
                .HasRequired(s => s.Leader)
                .WithOptional(ad => ad.Person);

            modelBuilder.Entity<Person>()
                .HasRequired(s => s.Professor)
                .WithOptional(ad => ad.Person);




            modelBuilder.Entity<IdentityUserRole>().HasKey(s => new { s.RoleId, s.UserId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(s => s.UserId);

        }

    }
}