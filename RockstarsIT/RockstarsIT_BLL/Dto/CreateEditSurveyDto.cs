using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_BLL.Dto
{
    public class CreateEditSurveyDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CreateEditQuestionDto> Questions { get; set; }
    }
}
