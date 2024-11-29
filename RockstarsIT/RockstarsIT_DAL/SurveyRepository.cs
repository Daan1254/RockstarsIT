using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;
using System.Data;

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
    
    public bool DeleteSquad(int id)
    {
        try
        {
            SurveyEntity? survey = _context.Surveys.Find(id);
            if (survey != null)
            {
                throw new Exception("Survey not found");
            }
            survey.DeletedAt = DateTime.Now;

            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred wile deleteing survey", e);
        }

    }
}