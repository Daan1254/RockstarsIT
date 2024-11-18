using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;

namespace RockstarsIT_DAL;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ISquadRepository _squadRepository;

    public CompanyRepository(ApplicationDbContext context, ISquadRepository squadRepository)
    {
        _context = context;
        _squadRepository = squadRepository;
    }

    public List<CompanyDTO> GetAllCompanies()
    {
        try
        {
            var companies = _context.Companies
                            .Select(c => new CompanyDTO
                            {
                              Id = c.Id,
                            })
                              .ToList();
            return companies;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting all companies.", ex);
        }
    }

    public void UpdateCompanyEntityId(int squadId, int companyEntityId)
    {
        try
        {
            SquadDto squad = _squadRepository.GetSquadById(squadId);
            var squadEntity = _context.Squads.FirstOrDefault(s => s.Id == squadId);
            if (squadEntity != null)
            {
                squadEntity.CompanyEntityId = companyEntityId;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Squad not found in context.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the CompanyEntityId.", ex);
        }
    }

    public void LinkCompany(CompanyDTO companyDTO, int squadId)
    {
        try
        {
            var squadEntity = _context.Squads.Find(squadId);

            if (squadEntity != null)
            {
                squadEntity.CompanyEntityId = companyDTO.Id;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Squad not found in the context.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while linking the company to the squad.", ex);
        }
    }

}
