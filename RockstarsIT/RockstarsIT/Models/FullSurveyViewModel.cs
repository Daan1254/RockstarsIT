namespace RockstarsIT.Models;

public class FullSurveyViewModel : SurveyViewModel
{
    public List<QuestionViewModel> Questions { get; set; } = new();
    public List<SquadViewModel> Squads { get; set; } = new();
}