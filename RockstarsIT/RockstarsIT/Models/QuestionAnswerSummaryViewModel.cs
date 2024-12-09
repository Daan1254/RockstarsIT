namespace RockstarsIT.Models
{
    public class QuestionAnswerSummaryViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int GreenCount { get; set; }
        public int YellowCount { get; set; }
        public int RedCount { get; set; }
    }
}
