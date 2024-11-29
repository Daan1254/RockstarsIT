using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ISurveyRepository
{
    
    public List<SurveyDto> GetAllSurveys();
    public SurveyDto? GetSurveyById (int id);

    public int CreateSurvey(CreateEditSurveyDto survey);

    public bool EditSurvey(int id, CreateEditSurveyDto surveyDTO);

    public bool DeleteSurvey(int id);
}