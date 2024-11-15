﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Dto;
using RockstarsIT_DAL.Data;
using RockstarsIT.Models;

namespace RockstarsIT.Controllers
{
    public class SquadController : Controller
    {
        
        private readonly SquadService _squadService;
        public SquadController(SquadService squadService)
        {
            _squadService = squadService;
        }

        // GET: Squads
        public async Task<IActionResult> Index()
        {
            List<SquadViewModel> squadViewModels = _squadService.GetSquads().Select(s => new SquadViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
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
        public async Task<IActionResult> Create(SquadViewModel squad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreateEditSquadDto squadDto = new CreateEditSquadDto()
                    {
                        Name = squad.Name,
                        Description = squad.Description
                    };
                    
                    _squadService.CreateSquad(squadDto);
                    return RedirectToAction("Index");
                }
                return View(squad);
            }
            catch (Exception e)
            {
                return View("Create");
            }
        }

        // GET: Squads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                SquadDto squadDto = _squadService.GetSquadById(int.Parse(id));
                
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

        // POST: Squads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SquadViewModel squadViewModel)
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
            } catch (Exception e)
            {
                return NotFound();
            }
        }

        // GET: Squads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            
            try
            {
                SquadDto squadDto = _squadService.GetSquadById(int.Parse(id));
                
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

        public IActionResult LinkCompany(int id)
        {

            return RedirectToAction("Index");
        }
    }
}
