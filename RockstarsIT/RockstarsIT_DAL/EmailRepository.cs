using System.Net;
using System.Net.Mail;
using dotenv.net;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL
{
    public class EmailRepository : IEmailRepository
    {
        private string _emailTemplate;
        private readonly ApplicationDbContext _context;

        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
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

        public string GetTemplate(string surveyTitle, string surveyDescription, string surveyLink)
        {
            return _emailTemplate.Replace("{{SurveyTitle}}", surveyTitle)
                .Replace("{{SurveyDescription}}", surveyDescription)
                .Replace("{{SurveyLink}}", surveyLink);
        }
        
      

        public void SendEmail(EmailDto emailDto)
        {
            string host = DotEnv.Read()["BRAVO_SMTP_HOST"];
            string port = DotEnv.Read()["BRAVO_SMTP_PORT"];
            string fromEmail = DotEnv.Read()["BRAVO_SMTP_FROM_EMAIL"];
            string userName = DotEnv.Read()["BRAVO_SMTP_USERNAME"];
            string password = DotEnv.Read()["BRAVO_SMTP_PASSWORD"];
            
            EmailEntity email = new EmailEntity
            {
                Email = emailDto.To,
                Subject = emailDto.Subject,
                UserId = emailDto.User.Id,
                SurveyId = emailDto.SurveyId,
                CreatedAt = DateTime.Now
            };

            try
            {
                MailMessage mail = new MailMessage(fromEmail, emailDto.To)
                {
                    Subject = emailDto.Subject,
                    Body = emailDto.Body,
                    IsBodyHtml = true
                };

                using var smtp = new SmtpClient(host, int.Parse(port));
                smtp.Credentials = new NetworkCredential(userName, password);
                smtp.Send(mail);
                email.Status = EmailStatus.Sent;
                email.SentAt = DateTime.Now;
            } catch(Exception e)
            {
                email.Status = EmailStatus.Failed;
                email.FailedAt = DateTime.Now;
                throw new Exception("An error occurred while sending the email", e);
            }
            
            _context.Emails.Add(email);
            _context.SaveChanges();
        }
    }
}
