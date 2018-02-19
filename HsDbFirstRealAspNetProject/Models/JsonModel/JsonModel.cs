// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Hearthstone;
//
//    var hs = Hs.FromJson(jsonString);

namespace Hearthstone
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Hs
    {
        public int Id { get; set; }
        [JsonProperty("Basic")]
        public List<Basic> Basic { get; set; }

        [JsonProperty("Classic")]
        public List<Basic> Classic { get; set; }

        [JsonProperty("Hall of Fame")]
        public List<Basic> HallOfFame { get; set; }

        [JsonProperty("Naxxramas")]
        public List<Basic> Naxxramas { get; set; }

        [JsonProperty("Goblins vs Gnomes")]
        public List<Basic> GoblinsVsGnomes { get; set; }

        [JsonProperty("Blackrock Mountain")]
        public List<Basic> BlackrockMountain { get; set; }

        [JsonProperty("The Grand Tournament")]
        public List<Basic> TheGrandTournament { get; set; }

        [JsonProperty("The League of Explorers")]
        public List<Basic> TheLeagueOfExplorers { get; set; }

        [JsonProperty("Whispers of the Old Gods")]
        public List<Basic> WhispersOfTheOldGods { get; set; }

        [JsonProperty("One Night in Karazhan")]
        public List<Basic> OneNightInKarazhan { get; set; }

        [JsonProperty("Mean Streets of Gadgetzan")]
        public List<Basic> MeanStreetsOfGadgetzan { get; set; }

        [JsonProperty("Journey to Un'Goro")]
        public List<Basic> JourneyToUnGoro { get; set; }

        [JsonProperty("Knights of the Frozen Throne")]
        public List<Basic> KnightsOfTheFrozenThrone { get; set; }

        [JsonProperty("Kobolds & Catacombs")]
        public List<Basic> KoboldsCatacombs { get; set; }

        [JsonProperty("Tavern Brawl")]
        public List<Basic> TavernBrawl { get; set; }

        [JsonProperty("Hero Skins")]
        public List<Basic> HeroSkins { get; set; }

        [JsonProperty("Missions")]
        public List<Basic> Missions { get; set; }

    }

    public partial class Basic
    {
        public int Id { get; set; }
        [JsonProperty("cardId")]
        public string CardId { get; set; }

        [JsonProperty("dbfId")]
        public string DbfId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cardSet")]
        public string CardSet { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("playerClass")]
        public string PlayerClass { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("mechanics")]
        public List<Mechanic> Mechanics { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("health")]
        public long? Health { get; set; }

        [JsonProperty("collectible")]
        public bool? Collectible { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("imgGold")]
        public string ImgGold { get; set; }

        [JsonProperty("attack")]
        public long? Attack { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("cost")]
        public long? Cost { get; set; }

        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("howToGet")]
        public string HowToGet { get; set; }

        [JsonProperty("howToGetGold")]
        public string HowToGetGold { get; set; }

        [JsonProperty("durability")]
        public long? Durability { get; set; }

        [JsonProperty("elite")]
        public bool? Elite { get; set; }

        [JsonProperty("multiClassGroup")]
        public string MultiClassGroup { get; set; }
        [JsonProperty("classes")]
        public List<string> Classes { get; set; }

        [JsonProperty("armor")]
        public string Armor { get; set; }
    }

    public partial class Mechanic
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Hs
    {
        public static Hs FromJson(string json) => JsonConvert.DeserializeObject<Hs>(json, Hearthstone.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Hs self) => JsonConvert.SerializeObject(self, Hearthstone.Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
