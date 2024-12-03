
namespace RockstarsIT_BLL.Dto;
    public class CreateEditSurveyDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> SquadIds { get; set; } = new();
    }
