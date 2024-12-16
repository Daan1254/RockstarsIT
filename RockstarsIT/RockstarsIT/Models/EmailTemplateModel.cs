namespace RockstarsIT.Models
{
    public class EmailTemplateModel
    {
        public string TemplateContent { get; set; }

        public EmailTemplateModel(string templateContent)
        {
            TemplateContent = templateContent;
        }
    }
}
