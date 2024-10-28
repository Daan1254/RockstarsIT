using System.Net;
using System.Net.Mail;
using dotenv.net;
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
    
    
    public IActionResult SendEmail(int id) {
        SurveyModel? survey = _context.Surveys.Find(id);
        
        // Define sender and recipient email addresses
        string host = DotEnv.Read()["BRAVO_SMTP_HOST"];
        string port = DotEnv.Read()["BRAVO_SMTP_PORT"];
        string fromEmail = DotEnv.Read()["BRAVO_SMTP_FROM_EMAIL"];
        string userName = DotEnv.Read()["BRAVO_SMTP_USERNAME"];
        string password = DotEnv.Read()["BRAVO_SMTP_PASSWORD"];
        string toEmail = "daanverbeek15@gmail.com";

        // Email message setup
        var mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = $"U bent uitgenodigd voor de {survey?.Title} enquête!";
        mail.Body = "Beste, <br> U bent uitgenodigd om de volgende enquête in te vullen: <br> <br> " +
                    $"<b>{survey?.Title}</b> <br> {survey?.Description} <br> <br> " +
                    "Klik op de volgende link om de enquête in te vullen: <br> " +
                    "<a href='http://localhost:5169/Survey/'>Klik hier om de enquête in te vullen</a>";

        mail.IsBodyHtml = true; // Make sure to set this so the HTML renders properly

        // Configure SMTP client
        using (var smtp = new SmtpClient(host, int.Parse(port)))
        {
            smtp.Credentials = new NetworkCredential(userName, password);
            smtp.Send(mail);
        }

        return View("Details", survey); 
    } 
}