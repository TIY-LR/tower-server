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
                }
                );
            context.Structures.AddOrUpdate(x => x.Type,
            new Structure()
            {
                Floor = 1,
                Income = 0,
                InitialCost = 1,
                IsResidence = true,
                PopulationCost = 0,
                SupportedPopulation = 5,
                Type = Structure.StructureType.Residence,
                UpKeep = 1,
                Game = context.Games.FirstOrDefault()
            },
            new Structure()
            {
                Floor = 2,
                Income = 3,
                InitialCost = 3,
                IsResidence = false,
                PopulationCost = 1,
                SupportedPopulation = 0,
                Type = Structure.StructureType.AmusementPark,
                UpKeep = 1,
                Game = context.Games.FirstOrDefault()
            },
            new Structure()
            {
                Floor = 3,
                Income = 2,
                InitialCost = 1,
                IsResidence = false,
                PopulationCost = 3,
                SupportedPopulation = 0,
                Type = Structure.StructureType.Restaurant,
                UpKeep = 1,
                Game = context.Games.FirstOrDefault()
            },
            new Structure()
            {
                Floor = 4,
                Income = 1,
                InitialCost = 1,
                IsResidence = false,
                PopulationCost = 1,
                SupportedPopulation = 0,
                Type = Structure.StructureType.Laundry,
                UpKeep = 1,
                Game = context.Games.FirstOrDefault()
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