using Game_Finder.Model.Models;
using Game_Finder.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Game_Finder_APi.Controllers
{   [Authorize]
    public class GameController : ApiController
    {
        public IHttpActionResult Get()
        {
            CreateGameService createGameService = CreateCreateGameService();
            var creatGameModels = createGameService.GetCreateGameModels();
            return Ok(createGameModels);
        }
        public IHttpActionResult Post(CreateGameModelCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameService();
            if (!service.CreateCreateGameModel(createGameModel))
                return InternalServerError();
            return Ok();
        }
        private CreateGameService CreateCreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var createGameService = new CreateGameService(userId);
            return createGameService;
        }
    }
}