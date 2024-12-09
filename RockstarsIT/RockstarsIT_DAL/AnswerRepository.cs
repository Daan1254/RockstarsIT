using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace RockstarsIT_DAL
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<QuestionAnswerSummaryDto> GetAnswerSummaryBySurveyId(int surveyId)
        {
            return _context.Questions
                .Where(q => q.SurveyId == surveyId)
                .Select(q => new QuestionAnswerSummaryDto
                {
                    QuestionTitle = q.Title,
                    GreenCount = q.Answers.Count(a => a.Result == 2),
                    YellowCount = q.Answers.Count(a => a.Result == 1),
                    RedCount = q.Answers.Count(a => a.Result == 0)
                })
                .ToList();
        }

        public string GetSurveyTitleById(int surveyId)
        {
            return _context.Surveys
                .Where(s => s.Id == surveyId)
                .Select(s => s.Title)
                .FirstOrDefault();
        }

    }
}
