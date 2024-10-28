using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models
{
    
    public class Squads
    {
        [Key]
        public string name { get; set; }
        public string description { get; set; }
    }
}
