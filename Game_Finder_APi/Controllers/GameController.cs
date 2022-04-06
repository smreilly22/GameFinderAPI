using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Game_Finder_APi.Controllers
{
    public class GameController : ApiController
    {
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetAllGames();
            return Ok(games);
        }
    }
}
