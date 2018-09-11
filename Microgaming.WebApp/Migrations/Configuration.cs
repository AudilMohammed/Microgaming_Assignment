namespace Microgaming.WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Microgaming.WebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Microgaming.WebApp.Models.ApplicationDbContext";
        }

        protected override void Seed(Microgaming.WebApp.Models.ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string role = "Admin";
            string password = "Password@1234";

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }

            //Create Admin users with password=123456
            var admin = new ApplicationUser();
            admin.UserName = "admin@admin.com";
            admin.Email = "admin@admin.com";
            admin.EmailConfirmed = true;
            UserManager.Create(admin, password);

            // Refetch user with ID:
            var user = context.Users.FirstOrDefault(x => x.UserName == admin.UserName);

            UserManager.AddToRole(user.Id, role);

            context.SaveChanges();
        }
    }
}
