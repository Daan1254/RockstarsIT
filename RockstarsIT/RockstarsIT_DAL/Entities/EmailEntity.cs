using Microsoft.AspNetCore.Identity;

namespace RockstarsIT_DAL.Entities;

public enum EmailStatus
{
    Pending = 0,
    Sent = 1,
    Failed = 2
}

public class EmailEntity
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public EmailStatus Status { get; set; } = EmailStatus.Pending;
    public int RetryCount { get; set; }
    public string ErrorMessage { get; set; }

    public IdentityUser User { get; set; }
    public string UserId { get; set; }

    public int SurveyId { get; set; }
    public SurveyEntity Survey { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime SendAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}