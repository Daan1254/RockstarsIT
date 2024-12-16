using RockstarsIT_BLL.Dto;

namespace RockstarsIT.Models;

public class AnswerViewModel
{
    public int Id { get; set; }
    public AnswerResult Result { get; set; }
    public string? Feedback { get; set; }
}
