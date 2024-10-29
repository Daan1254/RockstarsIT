using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockstarsIT.Models;

namespace RockstarsIT.Data;

public class ApplicationDbContext : IdentityDbContext
{
    
    
    public DbSet<SurveyModel> Surveys { get; set; }
    public DbSet<Squads> Squads { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}