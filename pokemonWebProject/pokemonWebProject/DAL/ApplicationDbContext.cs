using Microsoft.AspNet.Identity.EntityFramework;
using pokemonWebProject.Models;
using pokemonWebProject.Models.pokemonModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using static pokemonWebProject.Models.ApplicationUser;

namespace pokemonWebProject.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonSpecies> PokemonSpecieses { get; set; }
        public DbSet<Professor> Professors { get; set; }
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
                .HasRequired<ApplicationUser>(s => s.CurrentPerson)
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
            // one to many - SPECIES-POKEMON
            modelBuilder.Entity<Pokemon>()
                .HasRequired<PokemonSpecies>(s => s.PokemonSpecies)
                .WithMany(g => g.Pokemons)
                .HasForeignKey<int>(s => s.PokemonSpeciesID);

            // one to one - POKEMON-ACQUIRE
            modelBuilder.Entity<Pokemon>()
               .HasRequired(s => s.Acquire)
               .WithRequiredPrincipal(ad => ad.Pokemon);

            // one to zero/one - POKEMON
            modelBuilder.Entity<Pokemon>()
                .HasOptional(s => s.Fighter)
                .WithRequired(ad => ad.Pokemon);

            modelBuilder.Entity<Pokemon>()
                .HasOptional(s => s.Contester)
                .WithRequired(ad => ad.Pokemon);

            // one to zero/one - PERSON
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Trainer)
                .WithRequired(ad => ad.Person);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Leader)
                .WithRequired(ad => ad.Person);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Professor)
                .WithRequired(ad => ad.Person);


            modelBuilder.Entity<IdentityUserRole>().HasKey(s => new { s.RoleId, s.UserId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(s => s.UserId);
            modelBuilder.Entity<CustomUserLogin>().HasKey(s => s.UserId);
            modelBuilder.Entity<CustomUserRole>().HasKey(s => new { s.UserId, s.RoleId });


        }

        //public System.Data.Entity.DbSet<pokemonWebProject.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}