namespace pokemonWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        abilityID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        isHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.abilityID);
            
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        pokemonID = c.Int(nullable: false, identity: true),
                        nickname = c.String(),
                        gender = c.String(),
                        level = c.Int(nullable: false),
                        experience = c.Double(nullable: false),
                        happiness = c.Int(nullable: false),
                        CurrentPersonID = c.Int(nullable: false),
                        CurrentAbilityID = c.Int(nullable: false),
                        PokemonSpeciesID = c.Int(nullable: false),
                        FighterID = c.Int(nullable: false),
                        ContesterID = c.Int(nullable: false),
                        hpEvTrained = c.Int(),
                        attackEvTrained = c.Int(),
                        defenseEvTrained = c.Int(),
                        specialAttackEvTrained = c.Int(),
                        specialDefenseEvTrained = c.Int(),
                        speedEvTrained = c.Int(),
                        CurrentHeldItemID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Pokemon_pokemonID = c.Int(),
                    })
                .PrimaryKey(t => t.pokemonID)
                .ForeignKey("dbo.Abilities", t => t.CurrentAbilityID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.CurrentPersonID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.CurrentHeldItemID, cascadeDelete: true)
                .ForeignKey("dbo.Pokemons", t => t.Pokemon_pokemonID)
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesID, cascadeDelete: true)
                .Index(t => t.CurrentPersonID)
                .Index(t => t.CurrentAbilityID)
                .Index(t => t.PokemonSpeciesID)
                .Index(t => t.CurrentHeldItemID)
                .Index(t => t.Pokemon_pokemonID);
            
            CreateTable(
                "dbo.Contesters",
                c => new
                    {
                        contesterID = c.Int(nullable: false),
                        specialisation = c.String(),
                        PokemonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.contesterID)
                .ForeignKey("dbo.Pokemons", t => t.contesterID)
                .Index(t => t.contesterID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        secondName = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrainerID = c.Int(),
                        LeaderID = c.Int(),
                        ProfessorID = c.Int(),
                    })
                .PrimaryKey(t => t.personID);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        leaderID = c.Int(nullable: false),
                        specialisation = c.String(),
                        secondJob = c.String(),
                        sallary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.leaderID)
                .ForeignKey("dbo.People", t => t.leaderID)
                .Index(t => t.leaderID);
            
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        challengeID = c.Int(nullable: false, identity: true),
                        challengeDate = c.DateTime(nullable: false),
                        description = c.String(),
                        result = c.String(),
                        isAccepted = c.Boolean(nullable: false),
                        declineReasonTopic = c.String(),
                        declineReasonDescription = c.String(),
                        CurrentLeaderID = c.Int(nullable: false),
                        CurrentTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.challengeID)
                .ForeignKey("dbo.Leaders", t => t.CurrentLeaderID)
                .ForeignKey("dbo.Trainers", t => t.CurrentTrainerID)
                .Index(t => t.CurrentLeaderID)
                .Index(t => t.CurrentTrainerID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        trainerID = c.Int(nullable: false),
                        catchedPokemonsAmount = c.Int(nullable: false),
                        dexCompleteAmount = c.Int(nullable: false),
                        allowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.trainerID)
                .ForeignKey("dbo.People", t => t.trainerID)
                .Index(t => t.trainerID);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        licenseID = c.Int(nullable: false),
                        licenseCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.licenseID)
                .ForeignKey("dbo.Trainers", t => t.licenseID)
                .Index(t => t.licenseID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        professorID = c.Int(nullable: false),
                        specialisation = c.String(),
                        holdedPokemonAmount = c.Int(nullable: false),
                        sallary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.professorID)
                .ForeignKey("dbo.People", t => t.professorID)
                .Index(t => t.professorID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        itemID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        effect = c.String(),
                        canDrop = c.Boolean(),
                    })
                .PrimaryKey(t => t.itemID);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        moveID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        damageValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.moveID);
            
            CreateTable(
                "dbo.PokemonSpecies",
                c => new
                    {
                        pokemonSpeciesID = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        genre = c.String(),
                        BaseStatsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pokemonSpeciesID);
            
            CreateTable(
                "dbo.BaseStats",
                c => new
                    {
                        baseStatsID = c.Int(nullable: false),
                        hpStat = c.Int(nullable: false),
                        attackStat = c.Int(nullable: false),
                        defenseStat = c.Int(nullable: false),
                        specialAttackStat = c.Int(nullable: false),
                        specialDefenseStat = c.Int(nullable: false),
                        speedStat = c.Int(nullable: false),
                        PokemonSpeciesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.baseStatsID)
                .ForeignKey("dbo.PokemonSpecies", t => t.baseStatsID)
                .Index(t => t.baseStatsID);
            
            CreateTable(
                "dbo.PokeTypes",
                c => new
                    {
                        typeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.typeID);
            
            CreateTable(
                "dbo.Acquires",
                c => new
                    {
                        acquireID = c.Int(nullable: false, identity: true),
                        location = c.String(),
                        usedBall = c.String(),
                        objections = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.acquireID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PokemonspeciesAbility",
                c => new
                    {
                        PokemonSpeciesRefId = c.Int(nullable: false),
                        AbilityRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonSpeciesRefId, t.AbilityRefId })
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesRefId, cascadeDelete: true)
                .ForeignKey("dbo.Abilities", t => t.AbilityRefId, cascadeDelete: true)
                .Index(t => t.PokemonSpeciesRefId)
                .Index(t => t.AbilityRefId);
            
            CreateTable(
                "dbo.PokemonspeciesMove",
                c => new
                    {
                        PokemonSpeciesRefId = c.Int(nullable: false),
                        MoveRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonSpeciesRefId, t.MoveRefId })
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesRefId, cascadeDelete: true)
                .ForeignKey("dbo.Moves", t => t.MoveRefId, cascadeDelete: true)
                .Index(t => t.PokemonSpeciesRefId)
                .Index(t => t.MoveRefId);
            
            CreateTable(
                "dbo.PokemonspeciesType",
                c => new
                    {
                        PokemonSpeciesRefId = c.Int(nullable: false),
                        TypeRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonSpeciesRefId, t.TypeRefId })
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesRefId, cascadeDelete: true)
                .ForeignKey("dbo.PokeTypes", t => t.TypeRefId, cascadeDelete: true)
                .Index(t => t.PokemonSpeciesRefId)
                .Index(t => t.TypeRefId);
            
            CreateTable(
                "dbo.PokemonMove",
                c => new
                    {
                        PokemonRefId = c.Int(nullable: false),
                        MoveRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PokemonRefId, t.MoveRefId })
                .ForeignKey("dbo.Pokemons", t => t.PokemonRefId, cascadeDelete: true)
                .ForeignKey("dbo.Moves", t => t.MoveRefId, cascadeDelete: true)
                .Index(t => t.PokemonRefId)
                .Index(t => t.MoveRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Pokemons", "PokemonSpeciesID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonMove", "PokemonRefId", "dbo.Pokemons");
            DropForeignKey("dbo.Pokemons", "Pokemon_pokemonID", "dbo.Pokemons");
            DropForeignKey("dbo.PokemonspeciesType", "TypeRefId", "dbo.PokeTypes");
            DropForeignKey("dbo.PokemonspeciesType", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonspeciesMove", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.BaseStats", "baseStatsID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesAbility", "AbilityRefId", "dbo.Abilities");
            DropForeignKey("dbo.PokemonspeciesAbility", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.Pokemons", "CurrentHeldItemID", "dbo.Items");
            DropForeignKey("dbo.Pokemons", "CurrentPersonID", "dbo.People");
            DropForeignKey("dbo.Trainers", "trainerID", "dbo.People");
            DropForeignKey("dbo.Professors", "professorID", "dbo.People");
            DropForeignKey("dbo.Leaders", "leaderID", "dbo.People");
            DropForeignKey("dbo.Challenges", "CurrentTrainerID", "dbo.Trainers");
            DropForeignKey("dbo.Licenses", "licenseID", "dbo.Trainers");
            DropForeignKey("dbo.Challenges", "CurrentLeaderID", "dbo.Leaders");
            DropForeignKey("dbo.Pokemons", "CurrentAbilityID", "dbo.Abilities");
            DropForeignKey("dbo.Contesters", "contesterID", "dbo.Pokemons");
            DropIndex("dbo.PokemonMove", new[] { "MoveRefId" });
            DropIndex("dbo.PokemonMove", new[] { "PokemonRefId" });
            DropIndex("dbo.PokemonspeciesType", new[] { "TypeRefId" });
            DropIndex("dbo.PokemonspeciesType", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.PokemonspeciesMove", new[] { "MoveRefId" });
            DropIndex("dbo.PokemonspeciesMove", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.PokemonspeciesAbility", new[] { "AbilityRefId" });
            DropIndex("dbo.PokemonspeciesAbility", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.BaseStats", new[] { "baseStatsID" });
            DropIndex("dbo.Professors", new[] { "professorID" });
            DropIndex("dbo.Licenses", new[] { "licenseID" });
            DropIndex("dbo.Trainers", new[] { "trainerID" });
            DropIndex("dbo.Challenges", new[] { "CurrentTrainerID" });
            DropIndex("dbo.Challenges", new[] { "CurrentLeaderID" });
            DropIndex("dbo.Leaders", new[] { "leaderID" });
            DropIndex("dbo.Contesters", new[] { "contesterID" });
            DropIndex("dbo.Pokemons", new[] { "Pokemon_pokemonID" });
            DropIndex("dbo.Pokemons", new[] { "CurrentHeldItemID" });
            DropIndex("dbo.Pokemons", new[] { "PokemonSpeciesID" });
            DropIndex("dbo.Pokemons", new[] { "CurrentAbilityID" });
            DropIndex("dbo.Pokemons", new[] { "CurrentPersonID" });
            DropTable("dbo.PokemonMove");
            DropTable("dbo.PokemonspeciesType");
            DropTable("dbo.PokemonspeciesMove");
            DropTable("dbo.PokemonspeciesAbility");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Acquires");
            DropTable("dbo.PokeTypes");
            DropTable("dbo.BaseStats");
            DropTable("dbo.PokemonSpecies");
            DropTable("dbo.Moves");
            DropTable("dbo.Items");
            DropTable("dbo.Professors");
            DropTable("dbo.Licenses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Challenges");
            DropTable("dbo.Leaders");
            DropTable("dbo.People");
            DropTable("dbo.Contesters");
            DropTable("dbo.Pokemons");
            DropTable("dbo.Abilities");
        }
    }
}
