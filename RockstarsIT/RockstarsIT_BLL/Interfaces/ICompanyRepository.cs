using RockstarsIT_BLL.Dto;

namespace RockstarsIT_BLL.Interfaces
{
    public interface ICompanyRepository
    {
        public List<CompanyDTO> GetAllCompanies();
        public void UpdateCompanyEntityId(int squadId, int companyEntityId);

    }
}
