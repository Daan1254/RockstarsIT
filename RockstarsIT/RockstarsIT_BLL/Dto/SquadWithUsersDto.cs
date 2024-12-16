namespace RockstarsIT_BLL.Dto;

public class SquadWithUsersDto : SquadDto
{
    public List<UserDto> Users { get; set; }
}