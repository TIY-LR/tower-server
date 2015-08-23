using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class ApartmentVM
    {
        public int id { get; set; }
        public string type { get; set; }
        public int capacity { get; set; }
        public int cost { get; set; }
        public bool purchased { get; set; }
        public int floor { get; set; }
    }
}