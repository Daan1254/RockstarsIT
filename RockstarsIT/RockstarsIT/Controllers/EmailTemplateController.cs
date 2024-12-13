using Microsoft.AspNetCore.Mvc;
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

    }
}
