
namespace RockstarsIT_BLL.Dto;
    public class EmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        
        public string Body { get; set; }
        public UserDto User { get; set; }
        
        public int SurveyId { get; set; }
    }

