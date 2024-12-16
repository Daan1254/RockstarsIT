
namespace RockstarsIT_DAL.Entities;

public enum EmailStatus
{
    Pending,
    Sent,
    Failed
}

public class EmailEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public EmailStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime? FailedAt { get; set; }
    public string? ErrorMessage { get; set; }

    public string? RetryCount { get; set; }

    // make an survey relation 
    public int SurveyId { get; set; }
    public SurveyEntity Survey { get; set; }

    public string UserId { get; set; }
    public UserEntity User { get; set; }
}
