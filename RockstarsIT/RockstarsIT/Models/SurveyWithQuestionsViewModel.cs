namespace RockstarsIT.Models;

public class SurveyWithQuestionsViewModel : SurveyViewModel
{
    public List<QuestionViewModel> Questions { get; set; } = new();
}