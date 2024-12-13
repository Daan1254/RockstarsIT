using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_Tests
{
    public class TestRepoCompany : ICompanyRepository
    {
        public List<CompanyDto> _companyList = new List<CompanyDto>();
        public List<CompanyDto> GetAllCompanies()
        {
            return _companyList;
        }
    }
}
