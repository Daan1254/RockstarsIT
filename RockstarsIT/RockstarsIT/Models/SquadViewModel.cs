using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models
{
    
    public class SquadViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public CompanyViewModel? Company { get; set; }
    }
}
