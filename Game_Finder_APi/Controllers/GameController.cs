using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Game_Finder_APi.Controllers
{
    public class GameController : ApiController
    {

        //Create Game Service
        private GameService CreateGameService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(ownerId);
            return gameService;
        }

        public IHttpActionResult Post()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame())
                return InternalServerError();
            return Ok();
        }
    public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetAllGames();
            return Ok(games);
        }
        //Delete by Id
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameService();
            if (!service.DeleteGame(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
