using System.Data;
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
    
    public SquadDto? GetSquadById(int id)
    {
        try
        {
            return _squadRepository.GetSquadById(id);
        } catch (Exception e)
        {
            throw new Exception("An error occurred while getting a squad", e);
        }
    }
    
    public bool CreateSquad(CreateEditSquadDto squadDto)
    {
        try
        {
            return _squadRepository.CreateSquad(squadDto);
        }
        catch (DuplicateNameException ex)
        {
            throw new DuplicateNameException($"A squad with this name {squadDto.Name} already exists");
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while creating a squad", e);
        }
    }
    
    public bool EditSquad(int id, CreateEditSquadDto squadDto)
    {
        try
        {
            return _squadRepository.EditSquad(id, squadDto);
        } 
        catch (DuplicateNameException ex)
        {
            throw new DuplicateNameException($"A squad with this name {squadDto.Name} already exists");
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while editing a squad", e);
        }
    }
    
    public bool DeleteSquad(int id)
    {
        return _squadRepository.DeleteSquad(id);
    }

    public bool LinkCompany(LinkDisconnectCompanyDTO linkCompanyDto)
    {
         return _squadRepository.LinkCompany(linkCompanyDto);
    }

    public bool DisconnectCompany(LinkDisconnectCompanyDTO disconnectCompanyDTO)
    {
        return _squadRepository.DisconnectCompany(disconnectCompanyDTO);
    }

    public List<CompanyDto> GetLinkedCompaniesBySquadId(int squadId) 
    { 
        return _squadRepository.GetLinkedCompaniesBySquadId(squadId); 
    }


}