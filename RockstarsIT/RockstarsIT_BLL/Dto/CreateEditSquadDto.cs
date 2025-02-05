namespace RockstarsIT_BLL.Dto;

public class CreateEditSquadDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    public int CompanyId { get; set; }

    public List<string> UserIds { get; set; } = new List<string>();
}