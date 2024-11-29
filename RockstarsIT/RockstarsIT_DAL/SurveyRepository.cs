using Microsoft.EntityFrameworkCore;
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
            Id = s.Id,
            Title = s.Title,
            Description = s.Description
        }).ToList();
    }

    public SurveyDto GetSurveyById(int id)
    {
        try
        {
            // check if deletedAt is null
            SurveyEntity? survey = _context.Surveys
                .Include(survey => survey.Questions)
                .FirstOrDefault(s => s.Id == id);
                


            if (survey == null)
            {
                throw new Exception("Survey not found");
            }

            return new SurveyDto
            {
                Title = survey.Title,
                Description = survey.Description,
                Questions = survey.Questions.Select(q => new QuestionDto()
                {
                    Id = q.Id, 
                    Title = q.Title,
                    
                }).ToList(),
            };
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while getting squad by id", e);
        }
    }


    public int CreateSurvey(CreateEditSurveyDto survey)
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

    public bool EditSurvey (int id, CreateEditSurveyDto surveyDTO)
    {
        bool surveyNameExists = _context.Surveys.Any(s => s.Title == surveyDTO.Title && s.Id != id);

        if (surveyNameExists)
        {
            throw new DuplicateNameException($"Survey with this name {surveyDTO.Title} already exists");
        }

        SurveyEntity? survey = _context.Surveys.Find(id);

        if (survey == null)
        {
            throw new Exception("Survey not found");
        }

        surveyDTO.Title = surveyDTO.Title;
        surveyDTO.Description = surveyDTO.Description;
        surveyDTO.Questions = surveyDTO.Questions;

        _context.SaveChanges();
        return true;
    }
}