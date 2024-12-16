namespace RockstarsIT_DAL.Entities;

public class CompletedSurveyEntity
{
    public int Id { get; set; }

    public int SurveyId { get; set; }
    public SurveyEntity Survey { get; set; }

    public int SquadId { get; set; }
    public SquadEntity Squad { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}