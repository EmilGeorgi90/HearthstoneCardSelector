using Hearthstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class AdditionCardInfo
    {
        public int AdditionCardInfoId { get; set; }
        public bool Collectible { get; set; }
        public string Artist { get; set; }
        public long Cost { get; set; }
    }
}
