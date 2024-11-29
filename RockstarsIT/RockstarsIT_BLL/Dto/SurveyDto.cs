namespace RockstarsIT_BLL.Dto;

public class SurveyDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<CreateEditQuestionDto> Questions { get; set; }
}