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

        public IActionResult Index()
        {

            var answerDTOs = _answerRepository.GetAllAnswers();

            // Map de DTO naar ViewModel
            var viewModel = answerDTOs.Select(dto => new AnswerViewModel
            {
                Id = dto.Id,
                Result = dto.Result,
                Feedback = dto.Feedback,
            }).ToList();

            return View(viewModel);
        }
    }
}
