using Microsoft.AspNetCore.Identity;

namespace RockstarsIT_DAL.Entities;

public class SquadEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int? CompanyId { get; set; }
    public CompanyEntity? Company { get; set; }

    public List<UserEntity> Users { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}