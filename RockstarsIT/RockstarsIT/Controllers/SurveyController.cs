using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT_DAL.Data;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers;

public class SurveyController : Controller
{
    private readonly SurveyService _surveyService;

    // Injecting DbContext in the constructor
    public SurveyController(SurveyService surveyService)
    {
        _surveyService = surveyService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        List<SurveyDto> surveys = _surveyService.GetAllSurveys();
        
        // convert SurveyDto to SurveyViewModel
        List<SurveyViewModel> surveyViewModels = surveys.Select(s => new SurveyViewModel
        {
            Title = s.Title,
            Description = s.Description,
        }).ToList();
        
        return View(surveyViewModels);
    }
    
    public IActionResult Details(int? id)
    {
        // SurveyViewModel? survey = _context.Surveys.Find(id);
        //
        // if (survey == null)
        // {
        //     return NotFound();
        // }
        //
        return View(new SurveyViewModel());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("title,description")] SurveyViewModel survey)
    {
        if (!ModelState.IsValid)
        {
            return View(survey);
        }

        SurveyDto surveyDto = new()
        {
            Title = survey.Title,
            Description = survey.Description
        };

        // _surveyService.AddSurvey(surveyDto);

        return RedirectToAction(nameof(Index));
    }
}