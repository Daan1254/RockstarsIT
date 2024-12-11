using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockstarsIT_BLL.Dto;
namespace RockstarsIT_BLL.Interfaces
{
    public interface IEmailTemplateRepository
    {
        public string GetTemplate();
        //public void InitializeTemplate(string templateContent);
        //public void UpdateTemplate(string templateContent);
        //public void DeleteTemplate();
    }
}
