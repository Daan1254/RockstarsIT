using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL;

public class SurveyRepository : ISurveyRepository
{
    private readonly ApplicationDbContext _context;
    
    public SurveyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<SurveyDto> GetAllSurveys()
    {
        return _context.Surveys.Select(s => new SurveyDto
        {
            Title = s.Title,
            Description = s.Description
        }).ToList();
    }

    
    public int CreateSurvey(SurveyDto survey)
    {
        try {
            _context.Surveys.Add(new SurveyEntity
            {
                Title = survey.Title,
                Description = survey.Description,
            });
            
            _context.SaveChanges();

            return _context.Surveys.OrderByDescending(s => s.Id).First().Id;
        }
        catch (Exception ex) {
            throw new Exception("An error occurred while creating the survey.", ex);
        }
    }
}