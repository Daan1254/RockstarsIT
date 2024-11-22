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

    public void CreateSurveyWithQuestions(SurveyDto survey)
    {
        int surveyId = _surveyRepository.CreateSurvey(survey);
        
        foreach (QuestionDto question in survey.Questions)
        {
            question.SurveyId = surveyId;
            _questionRepository.CreateQuestion(question);
        }   
    }
}