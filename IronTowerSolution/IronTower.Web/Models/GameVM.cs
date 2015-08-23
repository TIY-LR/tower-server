using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class GameVM
    {
        public GameVM()
        {
            Structures = new Collection<GameStructureVM>();
        }
        public string ID { get; set; }
        public int PeriodicRevenue { get; set; }
        public int TotalBalance { get; set; }
        public ICollection<GameStructureVM> Structures {get;set;}
    }
}