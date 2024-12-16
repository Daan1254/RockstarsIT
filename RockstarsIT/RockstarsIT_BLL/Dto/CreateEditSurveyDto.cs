
namespace RockstarsIT_BLL.Dto;
    public class CreateEditSurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> SquadIds { get; set; } = new();
        public List<int> SquadIdsToDelete { get; set; } = new();
    }
