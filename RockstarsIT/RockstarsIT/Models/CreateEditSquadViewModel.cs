namespace RockstarsIT.Models;

public class CreateEditSquadViewModel : SquadViewModel
{
    public List<CompanyViewModel> Companies { get; set; } = new List<CompanyViewModel>();
    public List<CompanyViewModel> LinkedCompanies { get; set; } = new List<CompanyViewModel>();
}
