namespace RockstarsIT_BLL.Dto;

public class CompletedSurveyDto
{
    public int Id { get; set; }
    
    public FullSurveyDto Survey { get; set; }

    public SquadDto Squad { get; set; }
}