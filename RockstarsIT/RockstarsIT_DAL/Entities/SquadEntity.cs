namespace RockstarsIT_DAL.Entities;

public class SquadEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int? CompanyEntityId { get; set; }
    public CompanyEntity CompanyEntity { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}