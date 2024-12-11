using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers
{
    public class EmailTemplateController : Controller
    {
        private readonly EmailTemplateService _emailTemplateService;


        public EmailTemplateController(EmailTemplateService emailTemplateService)
        {
            _emailTemplateService = emailTemplateService;
        }

        public IActionResult Index()
        {
            var templateContent = _emailTemplateService.GetTemplate();

            var model = new EmailTemplateModel(templateContent);
            return View(model);
        }

        public IActionResult GetTemplate()
        {
            var templateDto = _emailTemplateService.GetTemplate();
            return View(templateDto); 
        }

        //[HttpPost]
        //public IActionResult InitializeTemplate(string templateContent)
        //{
        //    var templateDto = new EmailTemplateDto(templateContent);
        //    _emailTemplateService.InitializeTemplate(templateDto);
        //    return RedirectToAction("GetTemplate");
        //}


        //[HttpPost]
        //public IActionResult UpdateTemplate(string templateContent)
        //{
        //    var templateDto = new EmailTemplateDto(templateContent);
        //    _emailTemplateService.UpdateTemplate(templateDto.TemplateContent);
        //    return RedirectToAction("GetTemplate");
        //}

        //[HttpPost]
        //public IActionResult DeleteTemplate()
        //{
        //    _emailTemplateService.DeleteTemplate();
        //    return RedirectToAction("GetTemplate");
        //}
        //[HttpPost]
        //public IActionResult SendEmail(string squad, string subject, string message)
        //{
        //    if (string.IsNullOrWhiteSpace(squad) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(message))
        //    {
        //        TempData["Error"] = "Alle velden zijn verplicht.";
        //        return RedirectToAction("Index");
        //    }
            
        //    var squadEmails = SquadService.GetEmailsForSquad(squad);

        //    if (!squadEmails.Any())
        //    {
        //        TempData["Error"] = "Geen e-mailadressen gevonden voor de geselecteerde squad.";
        //        return RedirectToAction("Index");
        //    }

        //    try
        //    {
        //        _emailTemplateService.SendEmail(squadEmails, subject, message);

        //        TempData["Success"] = "E-mail succesvol verzonden.";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = $"Er is een fout opgetreden bij het verzenden: {ex.Message}";
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
