using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;

namespace RockstarsIT_Tests
{
    [TestClass]
    
    public class UnitTestsQuestionService
    {
        private QuestionService _questionService;

        [TestMethod]
        public void CreateQuestion_ShouldCreateQuestionSuccessfully()
        {
            //Arrange
            List<CreateEditQuestionDto> questionDtos = new List<CreateEditQuestionDto>();
            CreateEditQuestionDto question = new CreateEditQuestionDto { SurveyId = 1, Title = "What is the meaning of life?" };
            questionDtos.Add(question);

            //Act
            _questionService.CreateQuestion(question);

            //Assert

        }
    }
}
