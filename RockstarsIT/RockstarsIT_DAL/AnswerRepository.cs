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

        public List<AnswerDto> GetAllAnswers()
        {
            // Haal de antwoorden op en zet ze om naar AnswerDto
            return _context.Answers
                .Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Result = a.Result,
                    Feedback = a.Feedback
                })
                .ToList();
        }
    }
}
