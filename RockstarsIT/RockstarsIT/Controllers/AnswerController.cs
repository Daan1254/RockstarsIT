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
            var mockFullSurveyViewModel = new FullSurveyViewModel
            {
                Id = 1,
                Title = "Company Culture Survey 2024",
                Description = "Annual survey to measure employee satisfaction and company culture",
                Questions = new List<QuestionViewModel>
                {
                    new QuestionViewModel
                    {
                        Id = 1,
                        Title = "How satisfied are you with the company's work-life balance?",
                        Answers = new List<AnswerViewModel>
                        {
                            new AnswerViewModel
                            {
                                Id = 1,
                                Result = AnswerResult.LIKE,
                                Feedback = "Great flexibility with working hours and remote work options"
                            },
                            new AnswerViewModel
                            {
                                Id = 2,
                                Result = AnswerResult.NEUTRAL,
                                Feedback = "Generally good, but could use more flexibility during peak times"
                            }
                        }
                    },
                    new QuestionViewModel
                    {
                        Id = 2,
                        Title = "How would you rate the professional growth opportunities?",
                        Answers = new List<AnswerViewModel>
                        {
                            new AnswerViewModel
                            {
                                Id = 3,
                                Result = AnswerResult.LIKE,
                                Feedback = "Excellent training programs and mentorship opportunities"
                            },
                            new AnswerViewModel
                            {
                                Id = 4,
                                Result = AnswerResult.DISLIKE,
                                Feedback = "Would like to see more structured career progression paths"
                            }
                        }
                    },
                    new QuestionViewModel
                    {
                        Id = 3,
                        Title = "Rate the effectiveness of team collaboration tools",
                        Answers = new List<AnswerViewModel>
                        {
                            new AnswerViewModel
                            {
                                Id = 5,
                                Result = AnswerResult.LIKE,
                                Feedback = "Tools are good but we need better integration between systems"
                            }
                        }
                    }
                },
                Squads = new List<SquadViewModel>
                {
                    new SquadViewModel
                    {
                        Id = 1,
                        Name = "NS Developers team"
                    },
                    new SquadViewModel
                    {
                        Id = 2,
                        Name = "Rabobank Software Developers"
                    },
                    new SquadViewModel
                    {
                        Id = 3,
                        Name = "NS Developers"
                    }
                }
            };

            return View(mockFullSurveyViewModel);
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
