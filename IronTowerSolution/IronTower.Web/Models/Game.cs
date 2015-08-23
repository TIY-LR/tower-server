using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class Game
    {

        public int ID { get; set; }
        public int TotalBalance { get; set; }
        public int PeriodicRevenue
        {
            get
            {
                int sum = 0;
                foreach (Structure structure in this.Structures)
                {
                    sum += structure.Income;
                }
                return sum;
            }
        }
        public virtual ICollection<Structure> Structures { get; set; }

        public int TotalPopulation(Game game)
        {
            int population = 0;
            foreach (Structure structure in game.Structures)
            {
                population += structure.SupportedPopulation;
            }
            return population;
        }

        public int TotalFloors(Game game)
        {
            return game.Structures.LastOrDefault().Floor;
        }

        public int ConsumedPopulation(Game game)
        {
            int population = 0;
            foreach (Structure structure in game.Structures)
            {
                population += structure.PopulationCost;
            }
            return population;
        }
        public static bool PurchaseBuilding(int currencyRequired, int populationNeeded, Structure.StructureType strucureType)
        {
            IronTowerDBContext db = new IronTowerDBContext();
            Game game = db.Games.FirstOrDefault();
            if (game.TotalBalance < currencyRequired)
            { return false; }
            if (game.TotalPopulation(game) - game.ConsumedPopulation(game) < populationNeeded)
            { return false; }
            game.TotalBalance -= currencyRequired;

            Structure structure = new Structure(strucureType, game.TotalFloors(game) + 1);
            game.Structures.Add(structure);
            db.SaveChanges();
            return true;
        }
    }
}