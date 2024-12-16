namespace RockstarsIT.Models;

public class CreateEditSquadViewModel : SquadViewModel
{
    public CompanyViewModel? Company { get; set; }
    public List<CompanyViewModel> Companies { get; set; } = new List<CompanyViewModel>();
}
