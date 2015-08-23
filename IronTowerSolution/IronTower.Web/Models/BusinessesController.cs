using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IronTower.Web.Models
{
    public class BusinessesController : ApiController
    {
        IronTowerDBContext db = new IronTowerDBContext();
        IHttpActionResult Get()
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
    }
}
