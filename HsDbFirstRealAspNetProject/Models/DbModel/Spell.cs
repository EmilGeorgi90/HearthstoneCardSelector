using Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class Spell
    {
        public AdditionCardInfo CardInfo { get; set; }
        public int SpellId { get; set; }
        public string Flavor { get; set; }
        public string HowToGet { get; set; }
    }
}
