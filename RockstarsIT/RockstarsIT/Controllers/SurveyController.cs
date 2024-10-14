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
    
    
    public ViewResult SendEmail(int id) {
        Console.WriteLine("AAAAAAAAAAA");
            MailMessage mail = new MailMessage();
            mail.To.Add("daanverbeek15@gmail.com");  
            mail.From = new MailAddress("rockstarssssIT@gmail.com");  
            mail.Subject = "Test";  
            string Body = "<h1>XIN CHAO</h1>";  
            mail.Body = Body;  
            mail.IsBodyHtml = true;  
            SmtpClient smtp = new SmtpClient();  
            smtp.Host = "smtp.gmail.com";  
            smtp.Port = 465;
            smtp.EnableSsl = true;  
            smtp.UseDefaultCredentials = false;  
            smtp.Credentials = new System.Net.NetworkCredential("rockstarssssIT@gmail.com", "zijwoykrrfizitpz"); // Enter seders User name and password  
            smtp.Send(mail);
            return View("Index");
    } 
}