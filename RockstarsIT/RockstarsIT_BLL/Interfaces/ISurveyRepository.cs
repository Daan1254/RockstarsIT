using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ISurveyRepository
{
    
    public List<SurveyDto> GetAllSurveys();

    public int CreateSurvey(SurveyDto survey);
}