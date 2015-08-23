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

        /// <summary>
        /// This call should be passed an ID representing a particular user, and returns a 404 if it cannot retrieve the users game state, but otherwise returns the total currency the user has accured up to this pont.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>type=int</returns>
        public IHttpActionResult GetAccruedCurrency()
        {
            //if (GameExists(id))
            if (true)
            {
                int gameCurrency = db.Users.FirstOrDefault().Game.TotalBalance;
                return Ok(gameCurrency);
            }
            return NotFound();
        }

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
                        // Determine best error type to use for StructureNotFound
                        return NotFound();
                }
                //Change returns for error

            }
            return NotFound();
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get(string id)
        {
            Game game = db.Games.FirstOrDefault();
            GameVM vm = new GameVM();
            vm.id = game.ID.ToString();
            vm.periodicRevenue = game.PeriodicRevenue;
            vm.totalBalance = game.TotalBalance;
            return Ok(new EmberWrapper{ game = vm });
        }

        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame()
        {
            return Ok(db.Games.FirstOrDefault());
            //if (GameExists(id))
            //{
            //    Game game = db.Games.Find(id);
            //    return Ok(game);
            //}
            //return NotFound();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.ID)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = game.ID }, game);
        }

        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.ID == id) > 0;
        }
    }
}