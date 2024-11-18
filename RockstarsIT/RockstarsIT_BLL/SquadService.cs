using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL;

public class SquadService
{
    private readonly ISquadRepository _squadRepository;
    
    public SquadService(ISquadRepository squadRepository)
    {
        _squadRepository = squadRepository;
    }
    
    public List<SquadDto> GetSquads()
    {
        return _squadRepository.GetAllSquads();
    }
    
    public SquadDto GetSquadById(int id)
    {
        return _squadRepository.GetSquadById(id);
    }
    
    public bool CreateSquad(CreateEditSquadDto squadDto)
    {
        return _squadRepository.CreateSquad(squadDto);
    }
    
    public bool EditSquad(int id, CreateEditSquadDto squadDto)
    {
        return _squadRepository.EditSquad(id, squadDto);
    }
    
    public bool DeleteSquad(int id)
    {
        return _squadRepository.DeleteSquad(id);
    }

    public void LinkCompany(SquadDto squadDto, int companyId)
    {
        _squadRepository.LinkCompany(squadDto, companyId);
    }
}