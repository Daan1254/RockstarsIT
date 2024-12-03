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


    // Injecting DbContext in the constructor
    public SurveyController(SurveyService surveyService, QuestionService questionService, SquadService squadService)
    {
        _surveyService = surveyService;
        _questionService = questionService;
        _squadService = squadService;
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

        public IActionResult SendEmail(int id) {
        // SurveyViewModel? survey = _context.Surveys.Find(id);
        //
        // // Define sender and recipient email addresses
        // string host = DotEnv.Read()["BRAVO_SMTP_HOST"];
        // string port = DotEnv.Read()["BRAVO_SMTP_PORT"];
        // string fromEmail = DotEnv.Read()["BRAVO_SMTP_FROM_EMAIL"];
        // string userName = DotEnv.Read()["BRAVO_SMTP_USERNAME"];
        // string password = DotEnv.Read()["BRAVO_SMTP_PASSWORD"];
        // string toEmail = "daanverbeek15@gmail.com";
        //
        // // Email message setup
        // var mail = new MailMessage();
        // mail.From = new MailAddress(fromEmail);
        // mail.To.Add(toEmail);
        // mail.Subject = $"U bent uitgenodigd voor de {survey?.Title} enquête!";
        // mail.Body = "Beste, <br> U bent uitgenodigd om de volgende enquête in te vullen: <br> <br> " +
        //             $"<b>{survey?.Title}</b> <br> {survey?.Description} <br> <br> " +
        //             "Klik op de volgende link om de enquête in te vullen: <br> " +
        //             "<a href='http://localhost:5169/Survey/'>Klik hier om de enquête in te vullen</a>";
        //
        // mail.IsBodyHtml = true; // Make sure to set this so the HTML renders properly
        //
        // // Configure SMTP client
        // using (var smtp = new SmtpClient(host, int.Parse(port)))
        // {
        //     smtp.Credentials = new NetworkCredential(userName, password);
        //     smtp.Send(mail);
        // }
        //Template maken voor de emails. Dat er automatisch iets is ingevuld.
        //Het mag geen page zijn.
        //Denkt dat file/ template niet in presentation layer staat. 
        return View("Details", new SurveyViewModel()); 
    } 

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(SurveyViewModel survey)
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


        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {

        try
        {
            SurveyDto? surveyDto = _surveyService.GetSurveyById(id);


            if (surveyDto == null)
            {
                return NotFound();
            }
            
            List<SquadDto> allSquads = _squadService.GetSquads();

            List<SquadDto> squadsNotInSurvey = allSquads.Where(s => !surveyDto.Squads.Any(sq => sq.Id == s.Id)).ToList();

            SurveyViewModel surveyViewModel = new SurveyViewModel()
            {
                Id = surveyDto.Id,
                Title = surveyDto.Title,
                Description = surveyDto.Description,
                Questions = surveyDto.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Title = q.Title
                }).ToList(),
                AllSquads = squadsNotInSurvey.Select(s => new SquadViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }).ToList(),
                SelectedSquadIds = squadsNotInSurvey.Select(s => s.Id).ToList()
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
    public IActionResult Edit(SurveyViewModel surveyViewModel, List<QuestionViewModel> newQuestions, List<int> selectedSquadIds)
    {
        try
        {
            if (ModelState.IsValid)
            {
                CreateEditSurveyDto createEditSurveyDto = new CreateEditSurveyDto()
                {
                    Title = surveyViewModel.Title,
                    Description = surveyViewModel.Description,
                    SquadIds = selectedSquadIds
                };

                _surveyService.EditSurvey(surveyViewModel.Id, createEditSurveyDto);
                foreach (var question in surveyViewModel.Questions)
                {
                    CreateEditQuestionDto createEditQuestionDto = new CreateEditQuestionDto()
                    {
                        Title = question.Title,
                        SurveyId = surveyViewModel.Id,
                    };

                    if (question.Id != 0) 
                    {
                        _questionService.EditQuestion(question.Id, createEditQuestionDto);
                    }
                    else 
                    {
                        _questionService.CreateQuestion(createEditQuestionDto);
                    }
                }

                if (newQuestions != null)
                {
                    foreach (var newQuestion in newQuestions)
                    {
                        _questionService.CreateQuestion(new CreateEditQuestionDto()
                        {
                            Title = newQuestion.Title,
                            SurveyId = surveyViewModel.Id
                        });
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

}