using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT.Models;
using System.Data;

namespace RockstarsIT.Controllers;

public class SurveyController : Controller
{
    private readonly SurveyService _surveyService;
    private readonly QuestionService _questionService;
    private readonly SquadService _squadService;
    private readonly EmailService _emailService;


    // Injecting DbContext in the constructor
    public SurveyController(SurveyService surveyService, QuestionService questionService, SquadService squadService, EmailService emailService)
    {
        _surveyService = surveyService;
        _questionService = questionService;
        _squadService = squadService;
        _emailService = emailService;
    }
    
    // GET
    public IActionResult Index()
    {
        List<SurveyDto> surveys = _surveyService.GetAllSurveys();
        
        // convert SurveyDto to SurveyViewModel
        List<SurveyViewModel> surveyViewModels = surveys.Select(s => new SurveyViewModel
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
        }).ToList();
        
        return View(surveyViewModels);
    }

    public IActionResult Details(int id)
    {
        FullSurveyDto? survey = _surveyService.GetSurveyById(id);
        
        if (survey == null)
        {
            return NotFound();
        }
        
        FullSurveyViewModel surveyViewModel = new FullSurveyViewModel()
        {
            Id = survey.Id,
            Title = survey.Title,
            Description = survey.Description,
            Questions = survey.Questions.Select(q => new QuestionViewModel
            {
                Id = q.Id,
                Title = q.Title
            }).ToList(),
            Squads = survey.Squads.Select(s => new SquadViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            }).ToList()
        };
        
        return View(surveyViewModel);
    }

    public IActionResult SendEmail(int surveyId) {
        try
        {
            _emailService.SendEmails(surveyId);
            
            TempData["Message"] = "Emails zijn succesvol verstuurd";
        
            return RedirectToAction("Details", new { id = surveyId });
        }
        catch (Exception e)
        {
            TempData["Message"] = "Er is iets fout gegaan bij het versturen van de emails";
            return RedirectToAction("Details", new { id = surveyId });
        }
    } 

    public IActionResult Create()
    {
        return View();
    }
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateEditSurveyViewModel survey)
    {
        try 
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }

            CreateEditSurveyDto surveyDto = new()
            {
                Title = survey.Title,
                Description = survey.Description,
            };

            int surveyId = _surveyService.CreateSurvey(surveyDto);

            foreach (QuestionViewModel question in survey.Questions)
            {
                CreateEditQuestionDto createEditQuestionDto = new CreateEditQuestionDto()
                {
                    Title = question.Title,
                    SurveyId = surveyId
                };
                
                _questionService.CreateQuestion(createEditQuestionDto);
            }
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Er is iets fout gegaan bij het opslaan van de survey en vragen.";
            return View(survey);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {

        try
        {
            FullSurveyDto? surveyDto = _surveyService.GetSurveyById(id);


            if (surveyDto == null)
            {
                return NotFound();
            }
            
            List<SquadDto> allSquads = _squadService.GetSquads();

            // Filter out squads that are already on the survey
            List<SquadDto> filteredSquads = allSquads.Where(s => !surveyDto.Squads.Any(sq => sq.Id == s.Id)).ToList();

            CreateEditSurveyViewModel surveyViewModel = new CreateEditSurveyViewModel()
            {
                Id = surveyDto.Id,
                Title = surveyDto.Title,
                Description = surveyDto.Description,
                Questions = surveyDto.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Title = q.Title
                }).ToList(),
                Squads = surveyDto.Squads.Select(s => new SquadViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }).ToList(),
                AllSquads = filteredSquads.Select(s => new SquadViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }).ToList(),
            };
            return View(surveyViewModel);

        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Er is iets fout gegaan bij het ophalen van de squad";
            return View();
        }
    }

    // POST: Squads/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CreateEditSurveyViewModel surveyViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                CreateEditSurveyDto createEditSurveyDto = new CreateEditSurveyDto()
                {
                    Title = surveyViewModel.Title,
                    Description = surveyViewModel.Description,
                    SquadIds = surveyViewModel.SelectedSquadIds,
                    SquadIdsToDelete = surveyViewModel.SquadIdsToDelete
                };

                _surveyService.EditSurvey(surveyViewModel.Id, createEditSurveyDto);

                // Get the original survey to compare questions
                var originalSurvey = _surveyService.GetSurveyById(surveyViewModel.Id);
                var existingQuestionIds = originalSurvey.Questions.Select(q => q.Id).ToList();
                var updatedQuestionIds = surveyViewModel.Questions.Where(q => q.Id != 0).Select(q => q.Id).ToList();

                // Find questions that were deleted (exist in database but not in the form)
                var deletedQuestionIds = existingQuestionIds.Except(updatedQuestionIds);

                // Delete questions that were removed
                foreach (var questionId in deletedQuestionIds)
                {
                    _questionService.DeleteQuestion(questionId);
                }

                // Handle remaining questions
                if (surveyViewModel.Questions != null)
                {
                    foreach (var question in surveyViewModel.Questions)
                    {
                        CreateEditQuestionDto createEditQuestionDto = new CreateEditQuestionDto()
                        {
                            Title = question.Title,
                            SurveyId = surveyViewModel.Id,
                        };

                        // If Id is 0, it's a new question
                        if (question.Id == 0)
                        {
                            _questionService.CreateQuestion(createEditQuestionDto);
                        }
                        else
                        {
                            _questionService.EditQuestion(question.Id, createEditQuestionDto);
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", new { id = surveyViewModel.Id });
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Er is iets fout gegaan bij het opslaan van de survey en vragen.";
            return View(surveyViewModel);
        }
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _surveyService.DeleteSurvey(id);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Er is iets fout gegaan bij het verwijderen van de survey.";
            return RedirectToAction("Index");
        }
    }
}