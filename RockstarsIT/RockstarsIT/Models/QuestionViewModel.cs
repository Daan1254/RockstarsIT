namespace RockstarsIT.Models;

public class QuestionViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<AnswerViewModel> Answers { get; set; }
}