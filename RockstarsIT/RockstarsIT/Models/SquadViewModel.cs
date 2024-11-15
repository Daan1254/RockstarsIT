using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models
{
    
    public class SquadViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
