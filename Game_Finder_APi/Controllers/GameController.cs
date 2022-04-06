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
