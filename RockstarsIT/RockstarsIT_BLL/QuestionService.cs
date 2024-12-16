using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class QuestionService
{
    private readonly IQuestionRepository _questionRepository;
    
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
        
    
    public void CreateQuestion(CreateEditQuestionDto question)
    {
        try
        {
            _questionRepository.CreateQuestion(question);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating a question.", ex);
        }
    }
    
    
    public void EditQuestion(int id, CreateEditQuestionDto question)
    {
        try
        {
            _questionRepository.UpdateQuestion(id, question);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while editing a question.", ex);
        }
    }

    public void DeleteQuestion(int id)
    {
        try
        {
            _questionRepository.DeleteQuestion(id);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting a question.", ex);
        }
    }
}