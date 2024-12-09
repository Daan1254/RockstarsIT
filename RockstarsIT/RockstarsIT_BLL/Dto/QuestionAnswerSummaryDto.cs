using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_BLL.Dto
{
    public class QuestionAnswerSummaryDto
    {
        public string QuestionTitle { get; set; }
        public int GreenCount { get; set; }
        public int YellowCount { get; set; }
        public int RedCount { get; set; }
    }
}