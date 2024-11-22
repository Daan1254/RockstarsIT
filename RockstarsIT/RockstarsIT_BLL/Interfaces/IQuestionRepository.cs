using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface IQuestionRepository
{
  public IEnumerable<QuestionDto> GetQuestionsBySurveyId(int surveyId);
  public void CreateQuestion(QuestionDto question);
}