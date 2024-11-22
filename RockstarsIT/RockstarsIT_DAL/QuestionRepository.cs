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

    public List<QuestionDto> GetQuestionsBySurveyId(int surveyId) {
        return _context.Questions.Where(q => q.SurveyId == surveyId).Select(q => new QuestionDto {
            Id = q.Id,
            Title = q.Title
        }).ToList();
    }

    public void CreateQuestion(QuestionDto question) {
        _context.Questions.Add(new QuestionEntity {
            Title = question.Title,
            SurveyId = question.SurveyId
        });
        _context.SaveChanges();
    }
}