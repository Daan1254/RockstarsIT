using RockstarsIT_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_BLL
{
    public class EmailTemplateService
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public EmailTemplateService(IEmailTemplateRepository emailTemplateRepository)
        {
            _emailTemplateRepository = emailTemplateRepository;
        }

        public string GetTemplate()
        {
            return _emailTemplateRepository.GetTemplate();
        }

        //public void InitializeTemplate(string templateContent)
        //{
        //    _emailTemplateRepository.InitializeTemplate(templateContent);
        //}

        //public void UpdateTemplate(string templateContent)
        //{
        //    _emailTemplateRepository.UpdateTemplate(templateContent);
        //}

        //public void DeleteTemplate()
        //{
        //    _emailTemplateRepository.DeleteTemplate();
        //}
    }
}
