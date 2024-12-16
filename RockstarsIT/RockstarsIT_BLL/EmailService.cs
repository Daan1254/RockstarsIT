using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL
{
    public class EmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ISurveyRepository _surveyRepository;
        public EmailService(IEmailRepository emailRepository, ISurveyRepository surveyRepository)
        {
            _emailRepository = emailRepository;
            _surveyRepository = surveyRepository;
        }
        

        public void SendEmails(int surveyId)
        {

           FullSurveyDto? survey = _surveyRepository.GetSurveyById(surveyId);

           if (survey == null)
           {
            throw new Exception("Survey not found");
           }
           

           string emailTemplate = _emailRepository.GetTemplate(survey.Title, survey.Description, "http://localhost:5169/Survey/");
           
           survey.Squads.ForEach(squad => {
                squad.Users.ForEach(user => {
                    EmailDto emailDto = new EmailDto
                    {
                        To = user.Email,
                        Subject = "Er staat een nieuwe enquête voor u klaar!",
                        Body = emailTemplate,
                        User = user,
                        SurveyId = surveyId
                    };
                    _emailRepository.SendEmail(emailDto);
                });
           });

           
        
        // Email message setup
            // var mail = new MailMessage();
            // mail.From = new MailAddress(fromEmail);
            // mail.To.Add(toEmail);
            // mail.Subject = $"U bent uitgenodigd voor de {survey?.Title} enquête!";
            // mail.Body = "Beste, <br> U bent uitgenodigd om de volgende enquête in te vullen: <br> <br> " +
            //             $"<b>{survey?.Title}</b> <br> {survey?.Description} <br> <br> " +
            //             "Klik op de volgende link om de enquête in te vullen: <br> " +
            //             "<a href='http://localhost:5169/Survey/'>Klik hier om de enquête in te vullen</a>";
        
        // mail.IsBodyHtml = true; // Make sure to set this so the HTML renders properly
        }
    }
}
