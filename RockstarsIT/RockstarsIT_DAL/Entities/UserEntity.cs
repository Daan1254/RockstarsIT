using Microsoft.AspNetCore.Identity;

namespace RockstarsIT_DAL.Entities;

public class UserEntity : IdentityUser
{
    public int? SquadId { get; set; }
    public SquadEntity? Squad { get; set; }
}