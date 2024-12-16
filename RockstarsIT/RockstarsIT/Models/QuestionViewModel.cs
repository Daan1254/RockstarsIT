namespace RockstarsIT.Models;

public class QuestionViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<AnswerViewModel> Answers { get; set; } = new();
    public double AverageResult => Answers.Any() ? Answers.Average(a => (double)a.Result) : 0;
}