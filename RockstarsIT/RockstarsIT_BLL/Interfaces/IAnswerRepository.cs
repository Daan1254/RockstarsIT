using System.Collections.Generic;
using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces
{
    public interface IAnswerRepository
    {
        List<AnswerDto> GetAllAnswers(); 
    }
}
