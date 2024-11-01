using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using RockstarsIT.Data;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers;

public class SurveyController : Controller
{
    
    
    private readonly ApplicationDbContext _context;

    // Injecting DbContext in the constructor
    public SurveyController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View(new List<SurveyModel>());
    }
    
    public IActionResult Details(int? id)
    {
        SurveyModel? survey = _context.Surveys.Find(id);

        if (survey == null)
        {
            return NotFound();
        }
        
        return View(survey);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("title,description")] SurveyModel survey, List<QuestionModel> questions)
    {
        if (!ModelState.IsValid)
        {
            return View(survey);
        }

        survey.Questions = [.. questions];

        _context.Surveys.Add(survey);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}