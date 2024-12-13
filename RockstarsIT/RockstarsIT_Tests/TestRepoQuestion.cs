using Microsoft.Extensions.Hosting;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_Tests
{
    public class TestRepoQuestion : IQuestionRepository
    {
        List<CreateEditQuestionDto> questionsCreateEdit = new List<CreateEditQuestionDto>();
        List<QuestionDto> questions = new List<QuestionDto>();

        public void CreateQuestion(CreateEditQuestionDto questionCreated)
        {
            QuestionDto question = new QuestionDto()
            {
                Id = questions.Count + 1,
                Survey = new SurveyDto()
                {
                    Id = questionCreated.SurveyId
                },
                Title = questionCreated.Title,
                Answers = new List<AnswerDto>()
            };

            questions.Add(question);
        }

        public List<QuestionDto> GetQuestionsBySurveyId(int surveyId)
        {
            return questions.Where(question => question.Survey.Id == surveyId).ToList();
        }

        public void UpdateQuestion(int id, CreateEditQuestionDto question)
        {
            throw new NotImplementedException();
        }
    }
}
