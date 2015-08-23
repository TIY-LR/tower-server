using IronTower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IronTower.Web.Controllers
{
    public class ApartmentsController : ApiController
    {
        IronTowerDBContext db = new IronTowerDBContext();
        IHttpActionResult Get()
        {
            List<ApartmentVM> apartments = new List<ApartmentVM>();
            List<Structure> structures = db.Games.FirstOrDefault().Structures.ToList();
            if (structures == null)
                return NotFound();
            for (int i = 0; i < structures.Count(); i++)
            {
                if (structures[i].IsResidence)
                {
                    ApartmentVM vm = new ApartmentVM();
                    vm.id = structures[i].ID;
                    vm.capacity = structures[i].SupportedPopulation;
                    vm.purchased = true;
                    vm.type = "apartment";
                    vm.cost = structures[i].InitialCost;
                    apartments.Add(vm);
                }

            }
            return Ok(new EmberWrapper { apartments = apartments });
        }

    }
}
