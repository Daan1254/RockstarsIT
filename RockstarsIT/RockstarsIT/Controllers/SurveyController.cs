using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT_DAL.Data;
using RockstarsIT.Models;
using System.Data;
using RockstarsIT_BLL.Interfaces;

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
        //
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
            Questions = survey.Questions.Select(q => new CreateEditQuestionDto
            {
                Title = q.Title
            }).ToList()
        };

        _surveyService.CreateSurveyWithQuestions(surveyDto);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        try
        {
            SurveyDto? surveyDto = _surveyService.GetSurveyById(id);
            //List<SurveyDto> questions = IQuestionRepository.CreateQuestion();


            if (surveyDto == null)
            {
                return NotFound();
            }

            SurveyViewModel editSurveyViewModel = new SurveyViewModel()
            {
                Id = surveyDto.Id,
                Title = surveyDto.Title,
                Description = surveyDto.Description,
            };
            return View(editSurveyViewModel);

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
    public IActionResult Edit(SurveyViewModel surveyViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                CreateEditSurveyDto createEditSurveyDto = new CreateEditSurveyDto()
                {
                    Title = surveyViewModel.Title,
                    Description = surveyViewModel.Description
                };

                _surveyService.EditSurvey(surveyViewModel.Id, createEditSurveyDto);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", new { id = surveyViewModel.Id });
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    //GET: Survey/Delete/5
    public IActionResult Delete(string id)
    {
        try
        {
            SurveyDto? surveyDto = _surveyService.GetSurveyById(int.Parse(id));

            if (surveyDto == null)
            {
                return NotFound();
            }
            SurveyViewModel surveyviewModel = new SurveyViewModel()
            {
                Id = surveyDto.Id,
                Title = surveyDto.Title,
                Description = surveyDto.Description,
            };
            return View(surveyviewModel);
        } catch (Exception e)
        {
            return NotFound();
        }
    }

    //POST: Survey/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        try
        {
            _surveyService.DeleteSurvey(id);
            return RedirectToAction("Index");
        } catch (Exception e)
        {
            //return RedirectToAction("Index");
            return NotFound();
        }
    }
}