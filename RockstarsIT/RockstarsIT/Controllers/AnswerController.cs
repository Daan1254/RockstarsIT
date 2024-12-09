using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;  
using RockstarsIT.Models; 

namespace RockstarsIT.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }


        public IActionResult Index(int surveyId)
        {
            string surveyTitle = _answerRepository.GetSurveyTitleById(surveyId);
            List<QuestionAnswerSummaryDto> summaryDtos = _answerRepository.GetAnswerSummaryBySurveyId(surveyId);

            // Map DTO to ViewModel
            List<QuestionAnswerSummaryViewModel> viewModel = summaryDtos.Select(dto => new QuestionAnswerSummaryViewModel
            {
                QuestionTitle = dto.QuestionTitle,
                GreenCount = dto.GreenCount,
                YellowCount = dto.YellowCount,
                RedCount = dto.RedCount
            }).ToList();

            ViewBag.SurveyTitle = surveyTitle;

            return View(viewModel);
        }


    }
}
