
namespace RockstarsIT.Models;

public class CreateEditSurveyViewModel : FullSurveyViewModel
{
    public int CurrentQuestionId { get; set; }
    public List<SquadViewModel>? Squads { get; set; } = new();
    public List<int> selectedSquadIds { get; set; } = new();
    public List<int> SquadIdsToDelete { get; set; } = new();
}