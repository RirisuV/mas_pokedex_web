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
                        AbilityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AbilityID);
            
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        PokemonID = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Gender = c.String(),
                        Level = c.Int(nullable: false),
                        Experience = c.Double(nullable: false),
                        Happiness = c.Int(nullable: false),
                        CurrentPersonID = c.Int(nullable: false),
                        CurrentAbilityID = c.Int(nullable: false),
                        PokemonSpeciesID = c.Int(nullable: false),
                        FighterID = c.Int(nullable: false),
                        ContesterID = c.Int(nullable: false),
                        AcquireID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonID)
                .ForeignKey("dbo.Abilities", t => t.CurrentAbilityID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.CurrentPersonID, cascadeDelete: true)
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesID, cascadeDelete: true)
                .Index(t => t.CurrentPersonID)
                .Index(t => t.CurrentAbilityID)
                .Index(t => t.PokemonSpeciesID);
            
            CreateTable(
                "dbo.Acquires",
                c => new
                    {
                        AcquireID = c.Int(nullable: false),
                        PokemonID = c.Int(nullable: false),
                        Location = c.String(),
                        UsedBall = c.String(),
                        Objections = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AcquireID)
                .ForeignKey("dbo.Pokemons", t => t.AcquireID)
                .Index(t => t.AcquireID);
            
            CreateTable(
                "dbo.Contesters",
                c => new
                    {
                        ContesterID = c.Int(nullable: false),
                        Specialisation = c.String(),
                        PokemonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContesterID)
                .ForeignKey("dbo.Pokemons", t => t.ContesterID)
                .Index(t => t.ContesterID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        LeaderID = c.Int(nullable: false),
                        Specialisation = c.String(),
                        SecondJob = c.String(),
                        Sallary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaderID)
                .ForeignKey("dbo.People", t => t.LeaderID)
                .Index(t => t.LeaderID);
            
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        ChallengeID = c.Int(nullable: false, identity: true),
                        ChallengeDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Result = c.String(),
                        AsAccepted = c.Boolean(nullable: false),
                        DeclineReasonTopic = c.String(),
                        DeclineReasonDescription = c.String(),
                        CurrentLeaderID = c.Int(nullable: false),
                        CurrentTrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChallengeID)
                .ForeignKey("dbo.Leaders", t => t.CurrentLeaderID)
                .ForeignKey("dbo.Trainers", t => t.CurrentTrainerID)
                .Index(t => t.CurrentLeaderID)
                .Index(t => t.CurrentTrainerID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerID = c.Int(nullable: false),
                        CatchedPokemonsAmount = c.Int(nullable: false),
                        DexCompleteAmount = c.Int(nullable: false),
                        Allowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerID)
                .ForeignKey("dbo.People", t => t.TrainerID)
                .Index(t => t.TrainerID);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        LicenseID = c.Int(nullable: false),
                        LicenseCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LicenseID)
                .ForeignKey("dbo.Trainers", t => t.LicenseID)
                .Index(t => t.LicenseID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false),
                        Specialisation = c.String(),
                        HoldedPokemonAmount = c.Int(nullable: false),
                        Sallary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfessorID)
                .ForeignKey("dbo.People", t => t.ProfessorID)
                .Index(t => t.ProfessorID);
            
            CreateTable(
                "dbo.Fighters",
                c => new
                    {
                        FighterID = c.Int(nullable: false),
                        HpEvTrained = c.Int(nullable: false),
                        AttackEvTrained = c.Int(nullable: false),
                        DefenseEvTrained = c.Int(nullable: false),
                        SpecialAttackEvTrained = c.Int(nullable: false),
                        SpecialDefenseEvTrained = c.Int(nullable: false),
                        SpeedEvTrained = c.Int(nullable: false),
                        CurrentHeldItemID = c.Int(nullable: false),
                        PokemonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FighterID)
                .ForeignKey("dbo.Items", t => t.CurrentHeldItemID, cascadeDelete: true)
                .ForeignKey("dbo.Pokemons", t => t.FighterID)
                .Index(t => t.FighterID)
                .Index(t => t.CurrentHeldItemID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Effect = c.String(),
                        CanDrop = c.Boolean(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        MoveID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DamageValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoveID);
            
            CreateTable(
                "dbo.PokemonSpecies",
                c => new
                    {
                        PokemonSpeciesID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        BaseStatsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonSpeciesID);
            
            CreateTable(
                "dbo.BaseStats",
                c => new
                    {
                        BaseStatsID = c.Int(nullable: false),
                        HpStat = c.Int(nullable: false),
                        AttackStat = c.Int(nullable: false),
                        DefenseStat = c.Int(nullable: false),
                        SpecialAttackStat = c.Int(nullable: false),
                        SpecialDefenseStat = c.Int(nullable: false),
                        SpeedStat = c.Int(nullable: false),
                        PokemonSpeciesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BaseStatsID)
                .ForeignKey("dbo.PokemonSpecies", t => t.BaseStatsID)
                .Index(t => t.BaseStatsID);
            
            CreateTable(
                "dbo.PokeTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CustomRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            DropForeignKey("dbo.CustomUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.CustomUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.CustomUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Pokemons", "PokemonSpeciesID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonMove", "PokemonRefId", "dbo.Pokemons");
            DropForeignKey("dbo.PokemonspeciesType", "TypeRefId", "dbo.PokeTypes");
            DropForeignKey("dbo.PokemonspeciesType", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonspeciesMove", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.BaseStats", "BaseStatsID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesAbility", "AbilityRefId", "dbo.Abilities");
            DropForeignKey("dbo.PokemonspeciesAbility", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.Fighters", "FighterID", "dbo.Pokemons");
            DropForeignKey("dbo.Fighters", "CurrentHeldItemID", "dbo.Items");
            DropForeignKey("dbo.Pokemons", "CurrentPersonID", "dbo.People");
            DropForeignKey("dbo.Trainers", "TrainerID", "dbo.People");
            DropForeignKey("dbo.Professors", "ProfessorID", "dbo.People");
            DropForeignKey("dbo.Leaders", "LeaderID", "dbo.People");
            DropForeignKey("dbo.Challenges", "CurrentTrainerID", "dbo.Trainers");
            DropForeignKey("dbo.Licenses", "LicenseID", "dbo.Trainers");
            DropForeignKey("dbo.Challenges", "CurrentLeaderID", "dbo.Leaders");
            DropForeignKey("dbo.Pokemons", "CurrentAbilityID", "dbo.Abilities");
            DropForeignKey("dbo.Contesters", "ContesterID", "dbo.Pokemons");
            DropForeignKey("dbo.Acquires", "AcquireID", "dbo.Pokemons");
            DropIndex("dbo.PokemonMove", new[] { "MoveRefId" });
            DropIndex("dbo.PokemonMove", new[] { "PokemonRefId" });
            DropIndex("dbo.PokemonspeciesType", new[] { "TypeRefId" });
            DropIndex("dbo.PokemonspeciesType", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.PokemonspeciesMove", new[] { "MoveRefId" });
            DropIndex("dbo.PokemonspeciesMove", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.PokemonspeciesAbility", new[] { "AbilityRefId" });
            DropIndex("dbo.PokemonspeciesAbility", new[] { "PokemonSpeciesRefId" });
            DropIndex("dbo.CustomUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.BaseStats", new[] { "BaseStatsID" });
            DropIndex("dbo.Fighters", new[] { "CurrentHeldItemID" });
            DropIndex("dbo.Fighters", new[] { "FighterID" });
            DropIndex("dbo.Professors", new[] { "ProfessorID" });
            DropIndex("dbo.Licenses", new[] { "LicenseID" });
            DropIndex("dbo.Trainers", new[] { "TrainerID" });
            DropIndex("dbo.Challenges", new[] { "CurrentTrainerID" });
            DropIndex("dbo.Challenges", new[] { "CurrentLeaderID" });
            DropIndex("dbo.Leaders", new[] { "LeaderID" });
            DropIndex("dbo.Contesters", new[] { "ContesterID" });
            DropIndex("dbo.Acquires", new[] { "AcquireID" });
            DropIndex("dbo.Pokemons", new[] { "PokemonSpeciesID" });
            DropIndex("dbo.Pokemons", new[] { "CurrentAbilityID" });
            DropIndex("dbo.Pokemons", new[] { "CurrentPersonID" });
            DropTable("dbo.PokemonMove");
            DropTable("dbo.PokemonspeciesType");
            DropTable("dbo.PokemonspeciesMove");
            DropTable("dbo.PokemonspeciesAbility");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.PokeTypes");
            DropTable("dbo.BaseStats");
            DropTable("dbo.PokemonSpecies");
            DropTable("dbo.Moves");
            DropTable("dbo.Items");
            DropTable("dbo.Fighters");
            DropTable("dbo.Professors");
            DropTable("dbo.Licenses");
            DropTable("dbo.Trainers");
            DropTable("dbo.Challenges");
            DropTable("dbo.Leaders");
            DropTable("dbo.People");
            DropTable("dbo.Contesters");
            DropTable("dbo.Acquires");
            DropTable("dbo.Pokemons");
            DropTable("dbo.Abilities");
        }
    }
}
