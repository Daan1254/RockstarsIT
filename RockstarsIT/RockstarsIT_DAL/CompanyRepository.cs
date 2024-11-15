using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;

namespace RockstarsIT_DAL;

public class CompanyRepository
{

    private readonly ApplicationDbContext _context;
    private readonly ISquadRepository _squadRepository;

    public CompanyRepository(ApplicationDbContext context, ISquadRepository squadRepository)
    {
        _context = context;
        _squadRepository = squadRepository;
    }



    public void UpdateCompanyEntityId(int squadId, int companyEntityId)
    {
        try
        {
                SquadDto squad = _squadRepository.GetSquadById(squadId);
                squad.CompanyId = companyEntityId;
                _context.SaveChanges();
        }
        catch (Exception ex) 
        { 
            throw ex.InnerException;
        }
    }

}