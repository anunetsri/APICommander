using System.ComponentModel.DataAnnotations;

namespace APICommander.Models
{
    public class APICommand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }

}

 