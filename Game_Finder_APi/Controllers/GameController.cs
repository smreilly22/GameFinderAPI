using Game_Finder.Model.Models;
using Game_Finder.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

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