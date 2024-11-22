using System.ComponentModel.DataAnnotations.Schema;

namespace RockstarsIT_DAL.Entities;

[Table("Companies")]
public class CompanyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<SquadEntity> Squads { get; set; }
}
