using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT_DAL.Data;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers;

public class SurveyController : Controller
{
    
    
    private readonly ApplicationDbContext _context;

    private readonly SurveyService _surveyService;

    // Injecting DbContext in the constructor
    public SurveyController(ApplicationDbContext context, SurveyService surveyService)
    {
        _context = context;
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
}