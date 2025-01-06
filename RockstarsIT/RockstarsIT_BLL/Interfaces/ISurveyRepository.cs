using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ISurveyRepository
{
    
    public List<SurveyDto> GetAllSurveys();
    public FullSurveyDto? GetSurveyById (int id);

    public int CreateSurvey(CreateEditSurveyDto survey);

    public bool EditSurvey(int id, CreateEditSurveyDto surveyDTO);

    //List<SquadQuestionModeDto> GetModeAnswersPerSquad();
}