using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LolBackdoor.APIs.SummonerApis;
using LolBackdoor.Config;
using LolBackdoor.Data.SummonerData;
using SmurfTracker.ApiControllers;
using LolBackdoor = LolBackdoor.LolBackdoor;

namespace SE3800InClassProject.Controllers.Apis
{
    [RoutePrefix("api/summoner")]
    public class SummonerController : ApiController
    {
        public static global::LolBackdoor.LolBackdoor Lol;
        private readonly ISummonerApiController _summonerApiController;

        public SummonerController()
        {
            try
            {
                Lol = new global::LolBackdoor.LolBackdoor("../../../SmurfTracker/LolBackdoorConfig.xml");
            }
            catch (Exception e)
            {
                Lol = new global::LolBackdoor.LolBackdoor("LolBackdoorConfig.xml");
            }
            _summonerApiController = new SummonerApiController();
        }

        [ResponseType(typeof(LolSummoner))]
        public IHttpActionResult GetSummonerByName(string summonerName)
        {
            return Ok(_summonerApiController.GetSummonerBySummonerName(summonerName)[summonerName]);
        }
    }
}
