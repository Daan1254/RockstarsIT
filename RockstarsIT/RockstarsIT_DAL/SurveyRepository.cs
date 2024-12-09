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

    public FullSurveyDto? GetSurveyById(int id)
    {
        try
        {
            // check if deletedAt is null
            // please also include the answers related to the questions
            SurveyEntity? survey = _context.Surveys
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Answers)
                .Include(s => s.Squads)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                return null;
            }

            return new FullSurveyDto
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description,
                Questions = survey.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        Id = a.Id,
                        Result = a.Result,
                    }).ToList()
                }).ToList(),
                Squads = survey.Squads.Select(s => new SquadDto
                {
                    Id = s.Id,
                    Name = s.Name,
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

    public bool EditSurvey (int id, CreateEditSurveyDto surveyDto)
    {
        try {
            SurveyEntity? survey = _context.Surveys
                .Include(s => s.Squads)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                throw new Exception("Survey not found");
            }
    
            survey.Title = surveyDto.Title;
            survey.Description = surveyDto.Description;
    
            foreach (int squadId in surveyDto.SquadIdsToDelete)
            {
                SquadEntity? squad = _context.Squads.Find(squadId);
                
                if (squad != null)
                {
                    survey.Squads.Remove(squad);
                }
            }
    
    
            foreach (int squadId in surveyDto.SquadIds)
            {
                SquadEntity? squad = _context.Squads.Find(squadId);
                
                if (squad != null)
                {
                    survey.Squads.Add(squad);
                }
            }
    
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while editing the survey", e);
        }
    }
}