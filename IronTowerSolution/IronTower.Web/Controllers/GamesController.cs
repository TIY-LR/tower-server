using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IronTower.Web.Models;

// api/Games

namespace IronTower.Web.Controllers
{
    public class GamesController : ApiController
    {
        private IronTowerDBContext db = new IronTowerDBContext();

        [Route("api/businesses")]
        [HttpGet]
        IHttpActionResult GetBusinessses()
        {
            List<BusinessVM> businesses = new List<BusinessVM>();
            List<Structure> structures = db.Games.FirstOrDefault().Structures.ToList();
            if (structures == null)
                return NotFound();
            for (int i = 0; i < structures.Count(); i++)
            {
                if (!structures[i].IsResidence)
                {
                    BusinessVM vm = new BusinessVM();
                    vm.id = structures[i].ID;
                    vm.capacity = structures[i].SupportedPopulation;
                    vm.purchased = true;
                    vm.type = "business";
                    vm.cost = structures[i].InitialCost;
                    vm.floor = structures[i].Floor;
                    vm.income = structures[i].Income;
                    vm.upKeep = structures[i].UpKeep;
                    businesses.Add(vm);
                }

            }
            return Ok(new EmberWrapper { businesses = businesses });
        }

        [Route("api/purchasestructure")]
        [HttpPost]
        public IHttpActionResult PurchaseStructure(string structureType)
        {
            // Once users are implemented, can call "GameExists(id)
            if (true)
            {
                int currencyRequired = 0;
                int populationNeeded = 0;
                Game game = db.Games.FirstOrDefault();
                switch (structureType.ToLower().Trim())
                {
                    case "laundry":
                    case "laundrymat":
                    case "laundromat":
                        currencyRequired = 1;
                        populationNeeded = 1;
                        return Ok(Game.PurchaseBuilding(currencyRequired, populationNeeded, Structure.StructureType.Laundry));

                    case "restaurant":
                    case "restarant":
                    case "restauraunt":
                    case "restrant":
                        currencyRequired = 1;
                        populationNeeded = 3;
                        return Ok(Game.PurchaseBuilding(currencyRequired, populationNeeded, Structure.StructureType.Restaurant));


                    case "amusementpark":
                    case "amusement park":
                    case "park":
                    case "amusement":
                        currencyRequired = 3;
                        populationNeeded = 1;
                        return Ok(Game.PurchaseBuilding(currencyRequired, populationNeeded, Structure.StructureType.AmusementPark));

                    case "residence":
                    case "resedence":
                    case "apartment":
                    case "apartments":
                    case "houses":
                        currencyRequired = 1;
                        populationNeeded = 0;
                        return Ok(Game.PurchaseBuilding(currencyRequired, populationNeeded, Structure.StructureType.Residence));

                    default:
                        return BadRequest();
                }
            }
        }

        [Route(Name="api/games/me")]
        [HttpGet]
        public IHttpActionResult GetMe()
        {
            {
                Game game = db.Games.FirstOrDefault();
                GameVM vm = new GameVM();
                vm.ID = game.ID.ToString();
                vm.PeriodicRevenue = game.PeriodicRevenue;
                vm.TotalBalance = game.TotalBalance;
                vm.UnemployedPeople = game.TotalPopulation(game) - game.ConsumedPopulation(game);

                foreach (Structure structure in game.Structures)
                {
                GameStructureVM structureVM = new GameStructureVM();
                    structureVM.id = structure.ID;
                    structureVM.type = structure.Type.ToString();
                    vm.Structures.Add(structureVM);
                }
                return Ok(new EmberWrapper { game = vm });
            }
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.ID == id) > 0;
        }
    }
}