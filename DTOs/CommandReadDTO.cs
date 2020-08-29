using System.ComponentModel.DataAnnotations;

namespace APICommander.DTOs
{
    public class CommandReadDTO
    {
   
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        //public string Platform { get; set; } Implentation details needs to be hidden with Client
    }

}

 