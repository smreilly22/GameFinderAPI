using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Finder.Model.Models
{
    public class CreateGameListItem
    {
        public int GameId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Please Enter Atleast 2 Characters.")]
        [MaxLength(50, ErrorMessage = "There Are Too Many Characters For This Title.")]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = "There Are Too Many Characters For This Description")]
        public string Description { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}