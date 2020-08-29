
using System.ComponentModel.DataAnnotations;

namespace APICommander.DTOs
{
    public class CommandCreateDTO
    {
        [Required]
        [MaxLength(50)]
        //All the mandatory objects are mapped here to create a new entry in Database
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        //public string Platform { get; set; } Implentation details needs to be hidden with Client
         [Required]
        public string Platform { get; set; }
    }

}

 