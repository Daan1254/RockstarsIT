using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public bool LinkUserToSquad(string email, int squadId)
    {
        return _userRepository.LinkUserToSquad(email, squadId);
    }
}