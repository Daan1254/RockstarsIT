using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;

namespace RockstarsIT_Tests
{
    [TestClass]
    public class UnitTestCompanyService
    {
        private CompanyService _companyService;

        [TestMethod]
        public void GetAllCompanies_ShouldReturnAllCompanies()
        {

            //Arrange
            List<CompanyDto> expectedCompanies = new List<CompanyDto>();
            expectedCompanies.Add(new CompanyDto() { Id = 1, Name = "Company A" });
            expectedCompanies.Add(new CompanyDto() { Id = 2, Name = "Company B" });

            TestRepoCompany testRepo = new TestRepoCompany();
            testRepo._companyList.AddRange(expectedCompanies);

            _companyService = new CompanyService(testRepo);

            //Act
            List <CompanyDto> result = _companyService.GetAllCompanies();

            //Assert
            Assert.AreEqual(expectedCompanies.Count, result.Count);
            Assert.AreEqual(expectedCompanies[0].Name, result[0].Name); 
            Assert.AreEqual(expectedCompanies[1].Name, result[1].Name);
        }
    }
}