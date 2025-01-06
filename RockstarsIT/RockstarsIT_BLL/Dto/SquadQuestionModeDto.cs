using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_BLL.Dto
{
    public class SquadQuestionModeDto
    {
        public int SquadId { get; set; }
        public string SquadName { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string ModeAnswer { get; set; } // Meest voorkomende antwoord
    }
}