using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ISquadRepository
{
    public List<SquadDto> GetAllSquads();
    public SquadDto GetSquadById(int id);
    public bool CreateSquad(CreateEditSquadDto squadDto);
    
    public bool EditSquad(int id, CreateEditSquadDto squadDto);
    
    public bool DeleteSquad(int id);
    public bool LinkCompany(LinkDisconnectCompanyDto linkCompanyDto);
    public bool DisconnectCompany (LinkDisconnectCompanyDto disconnectCompanyDTO);
}