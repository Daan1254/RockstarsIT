namespace RockstarsIT_BLL.Dto;

public class SurveyDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public SquadDto? Squad { get; set; }
    public int ? SquadId { get; set; }
}