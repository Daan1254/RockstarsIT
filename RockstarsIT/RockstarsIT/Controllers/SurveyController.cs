using Microsoft.AspNetCore.Mvc;

namespace RockstarsIT.Controllers;

public class SurveyController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
   
}