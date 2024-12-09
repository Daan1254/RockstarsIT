using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserDto> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
    
    public bool LinkUserToSquad(string email, int squadId)
    {
        return _userRepository.LinkUserToSquad(email, squadId);
    }
}