using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;  
using RockstarsIT.Models; 

namespace RockstarsIT.Controllers
{
    public class AnswerController : Controller
    {
        private readonly SurveyService _surveyService;

        public AnswerController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }


        public IActionResult Index(int surveyId)
        {
            FullSurveyDto? survey = _surveyService.GetSurveyById(surveyId);

            if (survey == null)
            {
                return NotFound();
            }

            FullSurveyViewModel fullSurveyViewModel = new FullSurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description,
                Questions = survey.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Result = a.Result,
                        Feedback = a.Feedback 
                    }).ToList()
                }).ToList(),
                Squads = survey.Squads.Select(s => new SquadViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList()
            };

            return View(fullSurveyViewModel);
        }

        public IActionResult Chart(int surveyId)
        {
            FullSurveyDto? survey = _surveyService.GetSurveyById(surveyId);

            if (survey == null)
            {
                return NotFound();
            }

            FullSurveyViewModel fullSurveyViewModel = new FullSurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description,
                Questions = survey.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Result = a.Result,
                    }).ToList()
                }).ToList(),
                Squads = survey.Squads.Select(s => new SquadViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList()
            };

            return View(fullSurveyViewModel);
        }
    }
}
