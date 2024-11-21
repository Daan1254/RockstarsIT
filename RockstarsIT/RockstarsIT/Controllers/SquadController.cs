using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers
{
    public class SquadController : Controller
    {
        
        private readonly SquadService _squadService;
        private readonly CompanyService _companyService;

        public SquadController(SquadService squadService, CompanyService companyService)
        {
            _squadService = squadService;
            _companyService = companyService;
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

            Console.WriteLine(squadViewModels[0].Company?.Name);


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
                ViewData["ErrorMessage"] = ex.Message;
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
                SquadDto? squadDto = _squadService.GetSquadById(int.Parse(id));
                List<CompanyDto> companies = _companyService.GetAllCompanies();

               
                if (squadDto == null)
                {
                    return NotFound();
                }
                
                CreateEditSquadViewModel squadViewModel = new CreateEditSquadViewModel()
                {
                    Id = squadDto.Id,
                    Name = squadDto.Name,
                    Description = squadDto.Description,
                    Companies = companies.Select(s => new CompanyViewModel() { 
                        Id = s.Id,
                        Name = s.Name,
                    }).ToList()
                };

                Console.WriteLine(companies[0].Name);
                return View(squadViewModel);

            } catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
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
                TempData["ErrorMessage"] = ex.Message;
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
               LinkCompanyDto linkCompanyDto= new LinkCompanyDto
                {
                    CompanyId = companyId,
                    SquadId = squadId
                };

                _squadService.LinkCompany(linkCompanyDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
