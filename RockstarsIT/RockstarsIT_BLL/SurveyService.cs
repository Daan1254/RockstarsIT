using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class SurveyService
{
    
    private readonly ISurveyRepository _surveyRepository;
    
    public SurveyService(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
 
    
    public List<SurveyDto> GetAllSurveys()
    {
        return _surveyRepository.GetAllSurveys();
    }

    public FullSurveyDto? GetSurveyById(int id)
    {
        return _surveyRepository.GetSurveyById(id);
    }

    public int CreateSurvey(CreateEditSurveyDto survey)
    {
        try
        {
            return _surveyRepository.CreateSurvey(survey);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the survey", ex);
        }
    }

    public bool EditSurvey(int id, CreateEditSurveyDto surveyDto)
    {
        try
        {
            return _surveyRepository.EditSurvey(id, surveyDto);
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while editing the survey and its questions", e);
        }
    }


}