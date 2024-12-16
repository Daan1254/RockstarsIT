using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ISurveyRepository
{
    
    public List<SurveyDto> GetAllSurveys();
    public FullSurveyDto? GetSurveyById (int id);
    
    public List<CompletedSurveyDto> GetAllCompletedSurveys();

    public int CreateSurvey(CreateEditSurveyDto survey);

    public bool EditSurvey(int id, CreateEditSurveyDto surveyDTO);
}