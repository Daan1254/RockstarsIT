using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;

namespace RockstarsIT_DAL;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<CompanyDto> GetAllCompanies()
    {
        try
        {
            List<CompanyDto> companies = _context.Companies
                            .Select(c => new CompanyDto
                            {
                              Id = c.Id,
                              Name = c.Name,
                            })
                              .ToList();
            return companies;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting all companies.", ex);
        }
    }

}
