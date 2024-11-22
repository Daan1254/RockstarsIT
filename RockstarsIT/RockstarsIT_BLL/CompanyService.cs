using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;

namespace RockstarsIT_BLL
{
    public class CompanyService
    { 

        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public List<CompanyDto> GetAllCompanies()
        {
            return _companyRepository.GetAllCompanies(); 
        }

    }
}
