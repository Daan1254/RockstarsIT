using RockstarsIT_BLL.Dto;

namespace RockstarsIT_DAL.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }               
        public AnswerResult Result { get; set; }         
        public string? Feedback { get; set; }

        public int QuestionId { get; set; }
        public QuestionEntity Question { get; set; } = null!;


    }
}
