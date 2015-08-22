using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronTower.Web.Models
{
    public class Game
    {
        public ApplicationUser User { get; set; }
        public int CurrencyAccrued { get; set; }
    }
}