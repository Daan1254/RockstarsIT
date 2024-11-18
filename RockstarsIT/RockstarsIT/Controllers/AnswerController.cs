using Microsoft.AspNetCore.Mvc;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;  // Zorg ervoor dat je deze namespace gebruikt voor IAnswerRepository
using RockstarsIT.Models;  // Zorg ervoor dat de juiste ViewModel gebruikt wordt

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
            // Haal de antwoorden op uit de repository (zonder service-laag)
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
