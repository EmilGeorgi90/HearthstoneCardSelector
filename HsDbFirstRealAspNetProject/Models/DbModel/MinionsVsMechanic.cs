using Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class MinionsVsMechanic
    {
        public int MinionsVsMechanicId { get; set; }
        public Minion Minion { get; set; }
        public Mechanic Mechanic { get; set; }
    }
}
