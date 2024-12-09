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
            return _context.Squads.Select(s => new SquadDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Company = s.Company != null ? new CompanyDto()
                {
                    Name = s.Company.Name,
                    Id = s.Company.Id
                } : null
            }).ToList();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while getting all squads", e);
        }
    }
    
    public SquadWithUsersDto GetSquadById(int id)
    {
        try
        {
            // check if deletedAt is null
            SquadEntity? squad = _context.Squads
                .Include(squadEntity => squadEntity.Company)
                .Include(squadEntity => squadEntity.Users)
                .FirstOrDefault(s => s.Id == id);
            
            
            if (squad == null)
            {
                throw new Exception("Squad not found");
            }

            CompanyDto? company = null;
            if (squad.Company != null)
            {
                company = new CompanyDto()
                {
                    Id = squad.Company.Id,
                    Name = squad.Company.Name
                };
            }

            
            return new SquadWithUsersDto()
            {
                Id = squad.Id,
                Name = squad.Name,
                Description = squad.Description, 
                CompanyId = squad.CompanyId,
                Company = company,
                Users = squad.Users.Select(u => new UserDto()
                {
                    Id = u.Id,
                    Email = u.Email,
                }).ToList(),
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

    public bool LinkCompany(LinkCompanyDto linkCompanyDto)
    {
        try
        {
            SquadEntity? squadEntity = _context.Squads.Find(linkCompanyDto.SquadId);
            
            if (squadEntity == null)
            {
             
                throw new Exception("Squad not found in the context.");
            }
            
            squadEntity.CompanyId = linkCompanyDto.CompanyId;

            return _context.SaveChanges() == 1;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while linking the company to the squad.", ex);
        }
    }

    public bool LinkUser(LinkUserDto linkUserDto)
    {
        try
        {
            SquadEntity? squadEntity = _context.Squads.Find(linkUserDto.SquadId);
            
            if (squadEntity == null)
            {
             
                throw new Exception("Squad not found in the context.");
            }

            UserEntity? userEntity = _context.Users.Find(linkUserDto.UserId);

            if (userEntity == null)
            {
                throw new Exception("User not found in the context.");
            }

            userEntity.SquadId = linkUserDto.SquadId;

            return _context.SaveChanges() == 1;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while linking the company to the squad.", ex);
        }
    }
}