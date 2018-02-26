using Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class Minion
    {
        public AdditionCardInfo CardInfo { get; set; }
        public int MinionId { get; set; }
        public long Health { get; set; }
        public long Attack { get; set; }
    }
}
