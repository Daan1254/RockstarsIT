namespace RockstarsIT_BLL.Dto;

public class SurveyWithQuestionsDto : SurveyDto
{
    public List<QuestionDto> Questions { get; set; }
}