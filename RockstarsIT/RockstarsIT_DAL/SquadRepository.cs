using Microsoft.EntityFrameworkCore;
using RockstarsIT_BLL;
using System.Data;
using RockstarsIT_BLL.Dto;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL;

public class SquadRepository : ISquadRepository
{
    private readonly ApplicationDbContext _context;
    
    public SquadRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<SquadDto> GetAllSquads()
    {
        try
        {
            return _context.Squads.Where(s => s.DeletedAt == null).Select(s => new SquadDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Company = s.CompanyEntity != null ? new CompanyDto()
                {
                    Name = s.CompanyEntity.Name,
                    Id = s.CompanyEntity.Id
                } : null
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while getting all squads", e);
        }
    }
    
    public SquadDto GetSquadById(int id)
    {
        try
        {
            // check if deletedAt is null
            SquadEntity? squad = _context.Squads.Where(s => s.DeletedAt == null)
                .Include(squadEntity => squadEntity.CompanyEntity).FirstOrDefault(s => s.Id == id);
            
            
            if (squad == null)
            {
                throw new Exception("Squad not found");
            }
            
            CompanyDto company = new CompanyDto()
            {
                Id = squad.CompanyEntity.Id,
                Name = squad.CompanyEntity.Name,
            };

            return new SquadDto
            {
                Id = squad.Id,
                Name = squad.Name,
                Description = squad.Description, 
                CompanyId = squad.CompanyEntityId,
                Company = company,
                CreatedAt = squad.CreatedAt,
                UpdatedAt = squad.UpdatedAt,
                DeletedAt = squad.DeletedAt
            };
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while getting squad by id", e);
        }
    }

    public bool CreateSquad(CreateEditSquadDto squadDto)
    {
        // check if squad with name already exists
        bool squadNameExists = _context.Squads.Any(s => s.Name == squadDto.Name);
            
        if (squadNameExists)
        {
            throw new DuplicateNameException($"Squad with this name {squadDto.Name} already exists");
        }
            
        SquadEntity squad = new SquadEntity
        {
            Name = squadDto.Name,
            Description = squadDto.Description,
            CreatedAt = DateTime.Now 
        };
        
        _context.Squads.Add(squad);
        _context.SaveChanges();
        return true;
    }
    
    public bool EditSquad(int id, CreateEditSquadDto squadDto)
    { 
        bool squadNameExists = _context.Squads.Any(s => s.Name == squadDto.Name && s.Id != id);
            
        if (squadNameExists)
        {
            throw new DuplicateNameException($"Squad with this name {squadDto.Name} already exists");
        }
            
        SquadEntity? squad = _context.Squads.Find(id);
            
        if (squad == null)
        {
            throw new Exception("Squad not found");
        }

        squad.Name = squadDto.Name;
        squad.Description = squadDto.Description;
        squad.UpdatedAt = DateTime.Now;
            
        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteSquad(int id)
    {
        try
        {
            SquadEntity? squad = _context.Squads.Find(id);
            
            if (squad == null)
            {
                throw new Exception("Squad not found");
            }
            
            squad.DeletedAt = DateTime.Now;
            
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while deleting squad", e);
        }
    }

    public void LinkCompany(LinkCompanyDto linkCompanyDto)
    {
        try
        {
            var squadEntity = _context.Squads.Find(linkCompanyDto.SquadId);
            Console.WriteLine(linkCompanyDto.CompanyId);
            if (squadEntity != null)
            {
                squadEntity.CompanyEntityId = linkCompanyDto.CompanyId;

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