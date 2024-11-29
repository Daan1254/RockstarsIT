namespace RockstarsIT_BLL.Dto;
public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public SurveyDto Survey { get; set; }
}