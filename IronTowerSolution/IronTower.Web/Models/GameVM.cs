using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class GameVM
    {
        public string id { get; set; }
        public int periodicRevenue { get; set; }
        public int totalBalance { get; set; }
        public ICollection<GameStructureVM> structures {get;set;}
    }
}