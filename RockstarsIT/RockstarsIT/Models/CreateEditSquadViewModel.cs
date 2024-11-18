using RockstarsIT_BLL.Dto;

namespace RockstarsIT.Models;

public class CreateEditSquadViewModel : SquadViewModel
{
    public List<CompanyViewModel> Companies { get; set; }
}
