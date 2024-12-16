using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL;

public class QuestionRepository : IQuestionRepository {
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context) {
        _context = context;
    }
    
    public void CreateQuestion(CreateEditQuestionDto question) {
        try {
            _context.Questions.Add(new QuestionEntity {
                Title = question.Title,
                SurveyId = question.SurveyId
            });
            
            _context.SaveChanges();
        }
        catch (Exception ex) {
            throw new Exception("An error occurred while creating the question.", ex);
        }
        
    }

    public void UpdateQuestion(int id, CreateEditQuestionDto question)
    {
        try
        {
            QuestionEntity? existingQuestion = _context.Questions.Find(id);
            
            if (existingQuestion != null)
            {
                existingQuestion.Title = question.Title;
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the question.", ex);
        }
    }

    public void DeleteQuestion(int id)
    {
        try
        {
            QuestionEntity? question = _context.Questions.Find(id);
            
            if (question != null)
            {
                question.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting the question.", ex);
        }
    }

}