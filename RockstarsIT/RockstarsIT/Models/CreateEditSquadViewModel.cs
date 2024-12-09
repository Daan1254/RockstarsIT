using RockstarsIT_BLL.Dto;

namespace RockstarsIT.Models;

public class CreateEditSquadViewModel : SquadViewModel
{
    public List<CompanyViewModel> Companies { get; set; } = new List<CompanyViewModel>();
    public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
}
