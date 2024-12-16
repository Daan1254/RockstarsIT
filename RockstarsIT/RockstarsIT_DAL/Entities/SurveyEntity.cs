namespace RockstarsIT_DAL.Entities;

public class SurveyEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<QuestionEntity> Questions { get; set; }
    public List<SquadEntity> Squads { get; set; } = new();
}