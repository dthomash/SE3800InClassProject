using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;
using SE3800InClassProject.Controllers.Apis;
using SmurfTracker.Models;

namespace SmurfTracker.ApiControllers
{
    public class SummonerApiController : ISummonerApiController
    {
        public Dictionary<string, LolSummoner> GetSummonerBySummonerName(string summonerNames)
        {
            Dictionary<string, LolSummoner> summoners;
            var summonerNamesArray = summonerNames.Split(',');
            using (var db = new SE3800InClassContext())
            {
                summoners =
                    summonerNamesArray.Select(
                        name =>
                            db.Summoners.FirstOrDefault(summoner => summoner.SummonerName == name)
                                ?? db.Summoners.Add(SummonerController.Lol[LolRegion.NA].SummonerApi.GetSummonersBySummonerNames(new string[]{name}).First().Value))
                                .ToDictionary(summoner => summoner.SummonerName, summoner => summoner);
            }

            return summoners;
        }
    }
}