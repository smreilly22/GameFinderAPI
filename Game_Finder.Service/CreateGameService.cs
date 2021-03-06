using Game_Finder.Data;
using Game_Finder.Model.Models;
using GameFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Finder.Service
{
    public class CreateGameService
    {
        private readonly Guid _userId;
        public CreateGameService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCreateGameModel(CreateGameModelCreate model)
        {
            var entity =
                new CreateGameModel()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == gameId && e.OwnerId == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CreateGameListItem> GetCreateGameLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new CreateGameListItem
                    {
                        GameId = e.GameId,
                        Title = e.Title,
                        CreatedUtc = e.CreatedUtc
                    }
            );
                return query.ToArray();
            }
        }
    }
}
