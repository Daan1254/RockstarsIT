
using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces
{
    public interface IEmailRepository
    {
        public string GetTemplate(string surveyTitle, string surveyDescription, string surveyLink);

        public void SendEmail(EmailDto emailDto);
    }
}
