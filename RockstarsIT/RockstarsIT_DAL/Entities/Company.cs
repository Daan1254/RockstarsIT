using System.ComponentModel.DataAnnotations.Schema;

namespace RockstarsIT_DAL.Entities;

[Table("Companies")]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<SquadEntity> Squads { get; set; }
}
