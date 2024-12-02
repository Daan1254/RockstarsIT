using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using System.Data;

namespace RockstarsIT_BLL;

public class SurveyService
{
    
    private readonly ISurveyRepository _surveyRepository;
    private readonly IQuestionRepository _questionRepository;
    
    public SurveyService(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
    {
        _surveyRepository = surveyRepository;
        _questionRepository = questionRepository;
    }
 
    
    public List<SurveyDto> GetAllSurveys()
    {
        return _surveyRepository.GetAllSurveys();
    }

    public SurveyDto? GetSurveyById(int id)
    {
        return _surveyRepository.GetSurveyById(id);
    }
    
    public SurveyWithQuestionsDto? GetSurveyWithQuestionsById(int id)
    {
        try
        {
            return _surveyRepository.GetSurveyWithQuestionsById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting the survey with its questions", ex);
        }
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