using Microsoft.AspNetCore.Mvc;
using System.Data;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers
{
    public class SquadController : Controller
    {
        
        private readonly SquadService _squadService;
        private readonly CompanyService _companyService;
        private readonly UserService _userService;

        public SquadController(SquadService squadService, CompanyService companyService, UserService userService)
        {
            _squadService = squadService;
            _companyService = companyService;
            _userService = userService;
        }
        
        // GET: Squads
        public async Task<IActionResult> Index()
        {
            List<SquadViewModel> squadViewModels = _squadService.GetSquads().Select(s => new SquadViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Company = s.Company != null ? new CompanyViewModel()
                {
                    Id = s.Company.Id,
                    Name = s.Company.Name
                } : null
            }).ToList();

            return View(squadViewModels);
        }

        // GET: Squads/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                SquadDto squadDto = _squadService.GetSquadById(id);
                
                if (squadDto == null)
                {
                    return NotFound();
                }
            
                SquadViewModel squadViewModel = new SquadViewModel()
                {
                    Id = squadDto.Id,
                    Name = squadDto.Name,
                    Description = squadDto.Description
                };
            
                return View(squadViewModel);
            } catch (Exception e)
            {
                return NotFound();
            }
        }

        // GET: Squads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SquadViewModel squadViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateEditSquadDto squadDto = new CreateEditSquadDto()
                    {
                        Name = squadViewModel.Name,
                        Description = squadViewModel.Description
                    };
                    
                    _squadService.CreateSquad(squadDto);
                    return RedirectToAction("Index");
                }
                return View(squadViewModel);
            }
            catch (DuplicateNameException ex)
            {
                ViewData["ErrorMessage"] = "Er bestaat al een squad met deze naam";
                return View(squadViewModel);
            }
            catch (Exception e)
            {
                return View("Create");
            }
        }

        // GET: Squads/Edit/5
        public IActionResult Edit(string id)
        {
            try
            {
                SquadWithUsersDto? squadDto = _squadService.GetSquadById(int.Parse(id));
                List<CompanyDto> companies = _companyService.GetAllCompanies();
                List<UserDto> users = _userService.GetAllUsers();

               
                if (squadDto == null)
                {
                    return NotFound();
                }

                List<UserDto> filteredUsers = users.Where(u => !squadDto.Users.Any(su => su.Id == u.Id)).ToList();
                
                CreateEditSquadViewModel squadViewModel = new CreateEditSquadViewModel()
                {
                    Id = squadDto.Id,
                    Name = squadDto.Name,
                    Description = squadDto.Description,
                    Companies = companies.Select(s => new CompanyViewModel() { 
                        Id = s.Id,
                        Name = s.Name,
                    }).ToList(),
                    Users = filteredUsers.Select(u => new UserViewModel()
                    {
                        Id = u.Id,
                        Email = u.Email
                    }).ToList()
                };
                return View(squadViewModel);

            } catch (Exception e)
            {
                TempData["ErrorMessage"] = "Er is iets fout gegaan bij het ophalen van de squad";
                return View();
            }
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateEditSquadViewModel squadViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateEditSquadDto squadDto = new CreateEditSquadDto()
                    {
                        Name = squadViewModel.Name,
                        Description = squadViewModel.Description
                    };

                    _squadService.EditSquad(squadViewModel.Id, squadDto);
                    return RedirectToAction("Index");
                }

                return View(squadViewModel);
            }
            catch (DuplicateNameException ex)
            {
                TempData["ErrorMessage"] = "Er bestaat al een squad met deze naam";
                return RedirectToAction("Edit", new { id = squadViewModel.Id });
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // GET: Squads/Delete/5
        public IActionResult Delete(string id)
        {
            
            try
            {
                SquadDto? squadDto = _squadService.GetSquadById(int.Parse(id));
                
                if (squadDto == null)
                {
                    return NotFound();
                }
                
                SquadViewModel squadViewModel = new SquadViewModel()
                {
                    Id = squadDto.Id,
                    Name = squadDto.Name,
                    Description = squadDto.Description
                };
                return View(squadViewModel);

            } catch (Exception e)
            {
                return NotFound();
            }
        }

        // POST: Squads/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _squadService.DeleteSquad(id);
                return RedirectToAction("Index");
            } catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LinkCompany(int companyId, int squadId)
        {
            try
            {
               LinkCompanyDto linkCompanyDto = new LinkCompanyDto
                {
                    CompanyId = companyId,
                    SquadId = squadId
                };

                _squadService.LinkCompany(linkCompanyDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Er is iets fout gegaan bij het linken van de company aan de squad";
                return RedirectToAction("Details", new { id = squadId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LinkUser(string employeeId, int squadId)
        {
            try
            {
               LinkUserDto linkUserDto = new LinkUserDto
                {
                    UserId = employeeId,
                    SquadId = squadId
                };

                _squadService.LinkUser(linkUserDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Er is iets fout gegaan bij het linken van de company aan de squad";
                return RedirectToAction("Details", new { id = squadId });
            }
        }
    }
}
