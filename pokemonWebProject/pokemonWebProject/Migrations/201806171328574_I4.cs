namespace pokemonWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I4 : DbMigration
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
                "dbo.PokemonSpecies",
                c => new
                    {
                        pokemonSpeciesID = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        genre = c.String(),
                        BaseStatsID = c.Int(nullable: false),
                        pokemonID = c.Int(),
                        nickname = c.String(),
                        gender = c.String(),
                        level = c.Int(),
                        experience = c.Double(),
                        happiness = c.Int(),
                        CurrentPersonID = c.Int(),
                        CurrentAbilityID = c.Int(),
                        specialisation = c.String(),
                        hpEvTrained = c.Int(),
                        attackEvTrained = c.Int(),
                        defenseEvTrained = c.Int(),
                        specialAttackEvTrained = c.Int(),
                        specialDefenseEvTrained = c.Int(),
                        speedEvTrained = c.Int(),
                        CurrentHeldItemID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.pokemonSpeciesID)
                .ForeignKey("dbo.Abilities", t => t.CurrentAbilityID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.CurrentPersonID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.CurrentHeldItemID, cascadeDelete: true)
                .Index(t => t.CurrentPersonID)
                .Index(t => t.CurrentAbilityID)
                .Index(t => t.CurrentHeldItemID);
            
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
                "dbo.PokeTypes",
                c => new
                    {
                        typeID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.typeID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        secondName = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        specialisation = c.String(),
                        secondJob = c.String(),
                        sallary = c.Decimal(precision: 18, scale: 2),
                        catchedPokemonsAmount = c.Int(),
                        dexCompleteAmount = c.Int(),
                        allowance = c.Decimal(precision: 18, scale: 2),
                        specialisation1 = c.String(),
                        holdedPokemonAmount = c.Int(),
                        sallary1 = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.personID);
            
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
                .ForeignKey("dbo.People", t => t.CurrentLeaderID)
                .ForeignKey("dbo.People", t => t.CurrentTrainerID)
                .Index(t => t.CurrentLeaderID)
                .Index(t => t.CurrentTrainerID);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        licenseID = c.Int(nullable: false),
                        licenseCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.licenseID)
                .ForeignKey("dbo.People", t => t.licenseID)
                .Index(t => t.licenseID);
            
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
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonSpeciesRefId, cascadeDelete: false)
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
                .ForeignKey("dbo.PokemonSpecies", t => t.PokemonRefId, cascadeDelete: true)
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
            DropForeignKey("dbo.PokemonSpecies", "CurrentHeldItemID", "dbo.Items");
            DropForeignKey("dbo.PokemonSpecies", "PokemonSpeciesID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonMove", "PokemonRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonSpecies", "CurrentPersonID", "dbo.People");
            DropForeignKey("dbo.Challenges", "CurrentTrainerID", "dbo.People");
            DropForeignKey("dbo.Licenses", "licenseID", "dbo.People");
            DropForeignKey("dbo.Challenges", "CurrentLeaderID", "dbo.People");
            DropForeignKey("dbo.PokemonSpecies", "CurrentAbilityID", "dbo.Abilities");
            DropForeignKey("dbo.PokemonspeciesType", "TypeRefId", "dbo.PokeTypes");
            DropForeignKey("dbo.PokemonspeciesType", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesMove", "MoveRefId", "dbo.Moves");
            DropForeignKey("dbo.PokemonspeciesMove", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
            DropForeignKey("dbo.BaseStats", "baseStatsID", "dbo.PokemonSpecies");
            DropForeignKey("dbo.PokemonspeciesAbility", "AbilityRefId", "dbo.Abilities");
            DropForeignKey("dbo.PokemonspeciesAbility", "PokemonSpeciesRefId", "dbo.PokemonSpecies");
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
            DropIndex("dbo.Licenses", new[] { "licenseID" });
            DropIndex("dbo.Challenges", new[] { "CurrentTrainerID" });
            DropIndex("dbo.Challenges", new[] { "CurrentLeaderID" });
            DropIndex("dbo.BaseStats", new[] { "baseStatsID" });
            DropIndex("dbo.PokemonSpecies", new[] { "CurrentHeldItemID" });
            DropIndex("dbo.PokemonSpecies", new[] { "PokemonSpeciesID" });
            DropIndex("dbo.PokemonSpecies", new[] { "CurrentAbilityID" });
            DropIndex("dbo.PokemonSpecies", new[] { "CurrentPersonID" });
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
            DropTable("dbo.Items");
            DropTable("dbo.Licenses");
            DropTable("dbo.Challenges");
            DropTable("dbo.People");
            DropTable("dbo.PokeTypes");
            DropTable("dbo.Moves");
            DropTable("dbo.BaseStats");
            DropTable("dbo.PokemonSpecies");
            DropTable("dbo.Abilities");
        }
    }
}
