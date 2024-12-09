namespace RockstarsIT.Models;

public class FullSurveyViewModel : SurveyViewModel
{
    public List<QuestionViewModel> Questions { get; set; } = new();
    public List<SurveyViewModel> Squads { get; set; } = new();
}