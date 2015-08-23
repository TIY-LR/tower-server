using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class EmberWrapper
    {
        public ICollection<ApartmentVM> apartments { get; set; }
        public ICollection<BusinessVM> businesses { get; set; }
        public GameVM game { get; set; }
        public string structureType { get; set; }
    }
}