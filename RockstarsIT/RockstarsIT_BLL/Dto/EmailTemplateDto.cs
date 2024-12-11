using RockstarsIT_BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_BLL.Dto
{
    public class EmailTemplateDto
    {
        public string TemplateContent { get; set; }
        public EmailTemplateDto(string templateContent)
        {
            TemplateContent = templateContent;
        }
    }

}
