using Microsoft.AspNet.Identity.EntityFramework;
using pokemonWebProject.Models;
using System;
using System.Collections.Generic;
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

    }
}