namespace RockstarsIT_BLL.Dto;

public class FullSurveyDto : SurveyDto
{
    public List<QuestionDto> Questions { get; set; }
    public List<SquadDto> Squads { get; set; }
}