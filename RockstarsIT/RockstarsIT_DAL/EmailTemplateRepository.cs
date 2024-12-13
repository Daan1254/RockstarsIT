using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_DAL
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private string _emailTemplate;

        public EmailTemplateRepository()
        {
            _emailTemplate = @"
                        <html>
                        <body>
                            Beste, <br> 
                                U bent uitgenodigd om de volgende enquête in te vullen: <br> <br> 
                                <b>{{SurveyTitle}}</b> <br> 
                                {{SurveyDescription}} <br> <br> 
                                Klik op de volgende link om de enquête in te vullen: <br> 
                                <a href=""{{SurveyLink}}"">Klik hier om de enquête in te vullen</a>
                        </body>
                        </html>";
        }

        public string GetTemplate()
        {
            return _emailTemplate;
        }

    }
}
