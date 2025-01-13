namespace RockstarsIT_BLL.Dto;

public class SquadDto : MinimalSquadDto
{
    
    public int? CompanyId { get; set; }

    public List<UserDto> Users { get; set; }
    public CompanyDto? Company { get; set; }
  
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}