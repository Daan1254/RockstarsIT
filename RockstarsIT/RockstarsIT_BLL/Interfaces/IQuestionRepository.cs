using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface IQuestionRepository
{
  public List<QuestionDto> GetQuestionsBySurveyId(int surveyId);
  public void CreateQuestion(CreateEditQuestionDto question);
    public void UpdateQuestion(int id, CreateEditQuestionDto question);
}