namespace MVCResumeSite.Migrations
{
    using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCResumeSite.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCResumeSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCResumeSite.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCResumeSite.Models.ApplicationDbContext context)
        {
           var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

           if (!context.Roles.Any(r => r.Name == "Admin"))
               rm.Create(new IdentityRole { Name = "Admin" });

           var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
           var I = context.Users.FirstOrDefault(u => u.Email == "kbmilliren@northstate.net");

            if (I == null)
                um.Create(new ApplicationUser
            {
                UserName = "kbmilliren@northstate.net",
                Email = "kbmilliren@northstate.net",
                FirstName = "Bryant",
                LastName = "Milliren"
            }, "Std982582!");

            var My = um.FindByEmail("kbmilliren@northstate.net");
            if(!um.IsInRole(My.Id, "Admin"))
                um.AddToRole(My.Id, "Admin");
        }
    }
}
