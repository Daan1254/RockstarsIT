using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models
{
    
    public class Squads
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
