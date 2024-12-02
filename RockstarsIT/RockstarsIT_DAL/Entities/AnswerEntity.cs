using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_DAL.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }               
        public short Result { get; set; }         
        public string? Feedback { get; set; }

        public int QuestionId { get; set; }
        public QuestionEntity Question { get; set; } = null!;
    }
}
