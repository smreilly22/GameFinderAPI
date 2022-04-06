using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Finder.Model.Models
{
    public class CreateGameModelCreate
    {
            [Required]
            [MinLength(2, ErrorMessage = "Please Enter Atleast 2 Characters.")]
            [MaxLength(100, ErrorMessage = "There Are Too Many Characters In This Field.")]
            public string Title { get; set; }
            [MaxLength(8000)]
            public string Description { get; set; }
        }
    }