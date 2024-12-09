namespace RockstarsIT_BLL.Interfaces;

public interface IUserRepository
{
    public bool LinkUserToSquad(string email, int squadId);
}