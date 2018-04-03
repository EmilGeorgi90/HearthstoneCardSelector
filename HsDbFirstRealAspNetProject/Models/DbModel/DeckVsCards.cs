using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class DeckVsCards
    {
        public int DeckVsCardsId { get; set; }
        public Deck Deck { get; set; }
        public CardInfo Card { get; set; }
        public int LoginId { get; set; }
    }
}
