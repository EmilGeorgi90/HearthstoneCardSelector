using Hearthstone;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HsDbFirstRealAspNetProject.Models.DbModel
{
    public class CardInfo
    {
        public int CardInfoId { get; set; }
        public string CardId { get; set; }
        public string DbId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }
        public string CardSet { get; set; }
        public string Img { get; set; }
        public AdditionCardInfo AdditionCard { get; set; }
        public List<Mechanic> Mechanic { get; set; }
        public static implicit operator Basic(CardInfo cardInfo)
        {
            Basic basic = new Basic
            {
                CardId = cardInfo.CardId,
                DbfId = cardInfo.DbId,
                Name = cardInfo.Name,
                Type = cardInfo.Type,
                Text = cardInfo.Text,
                PlayerClass = cardInfo.Class,
                CardSet = cardInfo.CardSet,
                Img = cardInfo.Img
            };
            return basic;
        }
    }
}
