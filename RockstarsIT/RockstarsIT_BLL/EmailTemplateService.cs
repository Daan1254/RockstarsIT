using RockstarsIT_BLL.Interfaces;

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
    }
}
