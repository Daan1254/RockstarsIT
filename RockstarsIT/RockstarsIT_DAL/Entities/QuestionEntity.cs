namespace RockstarsIT_DAL.Entities;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int SurveyId { get; set; }
    public SurveyEntity Survey { get; set; }
    public List<AnswerEntity> Answers { get; set; } = new List<AnswerEntity>();

}