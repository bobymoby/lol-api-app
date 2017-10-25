using System;
using System.IO;
using System.Net;
using System.Text;

namespace LoLApiApp.Models
{
    public class Request
    {
        //        {
        //    "profileIconId": 3009,
        //    "name": "bobymoby",
        //    "summonerLevel": 30,
        //    "accountId": 210055342,
        //    "id": 46983305,
        //    "revisionDate": 1508955525000
        //}
        private static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
        }
        private const string KEY = "RGAPI-c024a786-f831-45a0-a1fa-d39434934c85";
        public static string GeTAllChampions(string region)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/champions?locale=en_US&dataById=false&api_key={ KEY }");
        }

        public static string GetChampById(string region, int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/champions/{ id.ToString() }?locale=en_US&api_key={ KEY }");
        }

        public static string GetAllItems(string region)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/items?locale=en_US&api_key={ KEY }");
        }

        public static string GetItemById(string region, int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/items/{ id.ToString() }?locale=en_US&api_key={ KEY }");
        }

        public static string GetAllSummonerSpells(string region)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/summoner-spells?locale=en_US&dataById=false&api_key={ KEY }");
        }

        public static string GetSummonerSpellById(string region, int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/summoner-spells/{ id.ToString() }?locale=en_US&api_key={ KEY }");
        }

        public static string GetAllIcons(string region)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/static-data/v3/profile-icons?locale=en_US&api_key={ KEY }");
        }

        public static int TotalMasteryScoreBySummonerId(string region, int id)
        {
            return int.Parse(GET($"https://{ region }.api.riotgames.com/lol/champion-mastery/v3/scores/by-summoner/{ id }?api_key={ KEY }"));
        }

        public static string MasteryBySummonerIdAndChampionId(string region, int summonerid, int championid)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/{ summonerid.ToString() }/by-champion/{ championid.ToString() }?api_key={ KEY }");
        }
        
        public static string RankedInfoBySummonerId(string region, int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/league/v3/positions/by-summoner/{ id.ToString() }?api_key={ KEY }");
        }

        public static string GetCurrentGameBySummonerId(string region,int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/spectator/v3/active-games/by-summoner/{ id.ToString() }?api_key={ KEY }");
        }

        public static string GetSummonerByName(string region, string name)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/summoner/v3/summoners/by-name/{ name }?api_key={ KEY }");
        }

        public static string GetSummonerById(string region, int id)
        {
            return GET($"https://{ region }.api.riotgames.com/lol/summoner/v3/summoners/{ id.ToString() }?api_key={ KEY }");
        }
    }
}