
namespace RockstarsIT_BLL.Dto;

public enum AnswerResult
{
    NEUTRAL = 1,
    LIKE = 2,
    DISLIKE = 3
}
public class AnswerDto // not used at the moment
{
    public int Id { get; set; }
    public AnswerResult Result { get; set; }
}
