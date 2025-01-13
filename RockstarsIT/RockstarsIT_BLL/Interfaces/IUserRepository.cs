using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface IUserRepository
{
    public List<UserDto> GetAllUsers();
    
    public UserDto? CreateUser(string email);
}