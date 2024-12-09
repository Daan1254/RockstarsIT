using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class AnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }


    public List<QuestionAnswerSummaryDto> GetSurveyAnswersSummary(int surveyId)
    {
        return _answerRepository.GetAnswerSummaryBySurveyId(surveyId);
    }
}