using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models;
    
public class SquadViewModel : MinimalSquadViewModel
{

    [Required]
    public string Description { get; set; }
    
    public CompanyViewModel? Company { get; set; }
}
