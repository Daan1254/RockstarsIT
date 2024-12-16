using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface IQuestionRepository
{
  public void CreateQuestion(CreateEditQuestionDto question);
  public void UpdateQuestion(int id, CreateEditQuestionDto question);
  public void DeleteQuestion(int id);
}