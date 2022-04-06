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
{
    [Authorize]
    public class GameController : ApiController
    {

        public IHttpActionResult Get()
        {
            CreateGameService createGameService = CreateCreateGameService();
            var createGameModels = createGameService.GetCreateGameLists();
            return Ok(createGameModels);
        }
        public IHttpActionResult Post(CreateGameModelCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCreateGameService();
            if (!service.CreateCreateGameModel(model))
                return InternalServerError();
            return Ok();
        }
        private CreateGameService CreateCreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var createGameService = new CreateGameService(userId);
            return createGameService;
        }
        //Delete by Id
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCreateGameService();
            if (!service.DeleteGame(id))
            {
                return InternalServerError();
            }
            return Ok();

        }
    }
}