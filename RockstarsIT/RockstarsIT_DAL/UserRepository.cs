using Microsoft.EntityFrameworkCore;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<UserDto> GetAllUsers()
    {
        return _context.Users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
        }).ToList();
    }
    
    public bool LinkUserToSquad(string email, int squadId)
    {
        UserEntity? user = _context.Users.FirstOrDefault(u => u.Email == email);
        
        if (user == null)
        {
            // throw NotFoundException
            return false;
        }
        
        user.SquadId = squadId;
        
        return _context.SaveChanges() == 1;
    }
    
}