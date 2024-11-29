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
        try
        {
            int surveyId = _surveyRepository.CreateSurvey(survey);
        
            foreach (CreateEditQuestionDto question in survey.Questions)
            {
                try {
                    question.SurveyId = surveyId;
                    _questionRepository.CreateQuestion(question);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while creating questions.", ex);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the survey with questions.", ex);
        }
    }
}