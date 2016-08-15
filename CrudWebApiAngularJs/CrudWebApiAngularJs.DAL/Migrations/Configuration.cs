namespace CrudWebApiAngularJs.DAL.Migrations
{
    using DAL.Configuration;
    using Entities;
    using Managers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudWebApiAngularJs.DAL.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrudWebApiAngularJs.DAL.TestContext context)
        {

            if (!context.Users.Any(u => u.UserName == "SuperAdmin"))
            {
                var rolemanager = new RoleManager<AppRole>(new RoleStore<AppRole>(context));
                rolemanager.Create(new AppRole("SuperAdmin", 1));
                rolemanager.Create(new AppRole("Admin", 2));
                rolemanager.Create(new AppRole("Manager", 3));
                rolemanager.Create(new AppRole("User", 4));

                //var userManager = new AppUserManager(new AppUserStore(context));
                var userManager = new AppUserManager(new AppUserStore(context));

                // Super admin
                var superAdmin = new AppUser() { UserName = "SuperAdmin", Email = "SuperAdmin@gmail.com" };
                userManager.Create(superAdmin, "SuperAdmin");
                userManager.AddToRole(superAdmin.Id, "SuperAdmin");
                userManager.AddToRole(superAdmin.Id, "User");

                // Test user
                var user = new AppUser() { UserName = "UserTest", Email = "user@gmail.com" };
                userManager.Create(user, "UserTest");
                userManager.AddToRole(user.Id, "User");
                // Test manager
                var manager = new AppUser() { UserName = "ManagerTest", Email = "manager@gmail.com" };
                userManager.Create(manager, "ManagerTest");
                userManager.AddToRole(manager.Id, "Manager");
                userManager.AddToRole(manager.Id, "User");
                // Test admin
                var admin = new AppUser() { UserName = "AdminTest", Email = "admin@gmail.com" };
                userManager.Create(admin, "AdminTest");
                userManager.AddToRole(admin.Id, "Admin");
                userManager.AddToRole(admin.Id, "Manager");
                userManager.AddToRole(admin.Id, "User");
            }
        }    
    }
}
