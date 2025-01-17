using RockstarsIT_BLL.Dto;

namespace RockstarsIT_DAL.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public AnswerResult Result { get; set; }
        public string? Feedback { get; set; }

        public int QuestionId { get; set; }
        public QuestionEntity Question { get; set; } = null!;

        public static string GetSeedDataSql()
        {
            return @"
                INSERT INTO Answers (QuestionId, Result, Feedback, CompletedSurveyId) VALUES
                (2, 0, 'Great team collaboration', 1),
                (2, 1, 'Could be improved', 2),
                (2, 2, 'Need better communication', 3),
                (2, 0, 'Love the work environment', 4),
                (2, 1, 'Neutral about current processes', 5),
                (2, 2, 'Tools need updating', 6),
                (2, 0, 'Excellent management', 7),
                (2, 1, 'Average experience', 8),
                (9, 2, 'Workload is too high', 9),
                (2, 0, 'Good work-life balance', 10),
                (2, 1, 'Satisfactory conditions', 11),
                (2, 2, 'More training needed', 12),
                (2, 0, 'Great learning opportunities', 13),
                (2, 1, 'Room for improvement', 14),
                (2, 2, 'Better planning required', 15),
                (2, 0, 'Positive team spirit', 16),
                (2, 1, 'Moderate satisfaction', 17),
                (2, 2, 'Communication issues', 18),
                (2, 0, 'Excellent resources', 19),
                (2, 2, 'Need more structure', 20);";
        }
    }
}
