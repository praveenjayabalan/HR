namespace HR.Migrations.Identity
{
    using HR.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HR.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(HR.Models.ApplicationDbContext context)
        {
            Console.WriteLine("seeding");
            //  This method will be called after migrating to the latest version.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Guest"))
                roleManager.Create(new IdentityRole("Guest"));

            string[] emails = { "Admin@gmail.com", "Guest@gmail.com" };
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            Console.WriteLine("emiallist");
            if (userManager.FindByEmail(emails[0]) == null)
            {
                var user = new ApplicationUser { Email = emails[0].ToString(), UserName = emails[0].ToString() };
                var result = userManager.Create(user,"123456");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            if (userManager.FindByEmail(emails[1]) == null)
            {
                var user = new ApplicationUser { Email = emails[1].ToString(), UserName = emails[1].ToString() };
                var result = userManager.Create(user, "123456");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Guest");
            }
        }
    }                                                                       
}
