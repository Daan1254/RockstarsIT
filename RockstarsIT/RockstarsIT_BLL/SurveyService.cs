using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using System.Data;

namespace RockstarsIT_BLL;

public class SurveyService
{
    
    private readonly ISurveyRepository _surveyRepository;
    private readonly IQuestionRepository _questionRepository;
    
    public SurveyService(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
    {
        _surveyRepository = surveyRepository;
        _questionRepository = questionRepository;
    }
 
    
    public List<SurveyDto> GetAllSurveys()
    {
        return _surveyRepository.GetAllSurveys();
    }

    public SurveyDto? GetSurveyById(int id)
    {
        return _surveyRepository.GetSurveyById(id);
    }

    public void CreateSurveyWithQuestions(CreateEditSurveyDto survey)
    {
        try
        {
            int surveyId = _surveyRepository.CreateSurvey(survey);
        
            foreach (CreateEditQuestionDto question in survey.Questions)
            {
                try {
                    question.SurveyId = surveyId;
                    _questionRepository.CreateQuestion(question);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while creating questions.", ex);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating the survey with questions.", ex);
        }
    }

    public bool EditSurvey(int id, CreateEditSurveyDto surveyDTO)
    {
        try
        {
            bool result = _surveyRepository.EditSurvey(id, surveyDTO);

            foreach (var question in surveyDTO.Questions)
            {
                _questionRepository.UpdateQuestion(new CreateEditQuestionDto
                {
                    Id = question.Id,
                    Title = question.Title,
                    SurveyId = id
                });
            }

            return result;
        }
        catch (DuplicateNameException ex)
        {
            throw new DuplicateNameException($"A survey with this name {surveyDTO.Title} already exists");
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while editing the survey and its questions", e);
        }
    }


}