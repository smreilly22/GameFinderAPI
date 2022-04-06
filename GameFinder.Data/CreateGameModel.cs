using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public enum GenreType
    {
        Platform = 1,
        Shooter = 2,
        Fighting = 3,
        Stealth = 4,
        Survival = 5,
        Rhythm = 6,
        BattleRoyal = 7,
        ActionAdventure = 8,
        Puzzle = 9,
        MMO = 10,
        MMORPG = 11,
        Simulation = 12,
        Racing = 13,
        Horror = 14,
        Sandbox = 15,
        OpenWorld = 16,
    }
    public enum AgeRating
    {
        Everyone = 1,
        Teen = 2,
        Mature = 3,
        Adults = 4
    }
    public enum SystemUsed
    {
        PC = 1,
        Xbox = 2,
        Playstation = 3,
        Nintendo = 4
    }

    public class CreateGameModel
    {
        public CreateGameModel() { }
        [Key]
        public int GameId { get; set; }
        [Required]
        public GenreType Genre { get; set; }
        [Required]
        public AgeRating Age { get; set; }
        [Required]
        public SystemUsed System { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public CreateGameModel(int gameId, string title, string description, GenreType genre, AgeRating age, SystemUsed system, Guid ownerId)
        {
            GameId = gameId;
            Title = title;
            Description = description;
            Genre = genre;
            Age = age;
            System = system;
            OwnerId = ownerId;
        }
    }
}