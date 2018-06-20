using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pokemonWebProject.DAL;
using pokemonWebProject.Models.pokemonModels;
using static pokemonWebProject.Models.ApplicationUser;

namespace pokemonWebProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public decimal Money { get; set; }

        // one to many
        public ICollection<Pokemon> Pokemons { get; set; }

        // kompozycja
        public virtual Trainer Trainer { get; set; }

        public virtual Leader Leader { get; set; }

        public virtual Professor Professor { get; set; }

        public double getCurrentAge()
        {
            return (DateTime.Now - DateOfBirth).TotalDays / 365;
        }



        // IDENTITY
        public class CustomUserRole : IdentityUserRole<int> { }
        public class CustomUserClaim : IdentityUserClaim<int> { }
        public class CustomUserLogin : IdentityUserLogin<int> { }

        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole() { }
            public CustomRole(string name) { Name = name; }
        }

        public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
            CustomUserLogin, CustomUserRole, CustomUserClaim>
        {
            public CustomUserStore(ApplicationDbContext context)
                : base(context)
            {
            }
        }

        public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
        {
            public CustomRoleStore(ApplicationDbContext context)
                : base(context)
            {
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}