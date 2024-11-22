using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces;

public interface ICompanyRepository
{
    public List<CompanyDto> GetAllCompanies();
}
