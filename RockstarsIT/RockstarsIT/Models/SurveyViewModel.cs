using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models;

public class SurveyViewModel
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public List<QuestionViewModel> Questions { get; set; } = new();
    public List<SquadViewModel> AllSquads { get; set; } = new();
    public List<int> SelectedSquadIds { get; set; } = new();
}