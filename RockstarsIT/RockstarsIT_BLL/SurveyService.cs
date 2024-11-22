using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

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

    public void CreateSurvey(SurveyDto survey)
    {
        foreach (var question in survey.Questions)
        {
            _questionRepository.CreateQuestion(question);
        }
        _surveyRepository.CreateSurvey(survey);
    }
}