using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class AnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public List<AnswerDto> GetAnswers()
    {
        // Fetch answers from repository and map to DTO
        var answers = _answerRepository.GetAllAnswers();
        return answers.Select(a => new AnswerDto
        {
            Id = a.Id,
            Result = a.Result,
            Feedback = a.Feedback
        }).ToList();
    }
}