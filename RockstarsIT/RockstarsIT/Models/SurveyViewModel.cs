using System.ComponentModel.DataAnnotations;

namespace RockstarsIT.Models;

public class SurveyViewModel
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}