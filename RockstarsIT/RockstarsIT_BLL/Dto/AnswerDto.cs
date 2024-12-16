
namespace RockstarsIT_BLL.Dto;

public enum AnswerResult
{
    NEUTRAL = 1,
    LIKE = 2,
    DISLIKE = 0
}
public class AnswerDto 
{
    public int Id { get; set; }
    public AnswerResult Result { get; set; }
    public string? Feedback { get; set; }
}
