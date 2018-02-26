using Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class Hero
    {
        public AdditionCardInfo CardInfo { get; set; }
        public int HeroId { get; set; }
        public long Health { get; set; }
    }
}
