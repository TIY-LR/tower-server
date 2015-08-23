namespace IronTower.Web.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<IronTower.Web.Models.IronTowerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IronTower.Web.Models.IronTowerDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");
            context.Games.AddOrUpdate(x => x.ID,
                new Game
                {
                    ID = 1,
                    TotalBalance = 5,
                    Structures = new List<Structure> { new Structure(Structure.StructureType.Residence, 1), new Structure(Structure.StructureType.Laundry, 2), new Structure(Structure.StructureType.Restaurant, 3), new Structure(Structure.StructureType.AmusementPark, 4)}
                }
                );
            context.Users.AddOrUpdate(
                x => x.UserName,
                new IronTowerUser
                {
                    UserName = "aaron@hudson.net",
                    PasswordHash = password,
                    Game = context.Games.FirstOrDefault()
                });
        }
    }
}