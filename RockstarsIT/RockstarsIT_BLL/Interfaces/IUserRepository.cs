using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface IUserRepository
{
    public List<UserDto> GetAllUsers();
    public bool LinkUserToSquad(string email, int squadId);
}