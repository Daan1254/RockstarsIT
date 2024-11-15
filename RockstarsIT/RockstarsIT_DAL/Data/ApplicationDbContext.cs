using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<SurveyEntity> Surveys { get; set; }
    public DbSet<SquadEntity> Squads { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SquadEntity>()
            .HasOne(s => s.CompanyEntity)
            .WithMany(c => c.Squads)
            .HasForeignKey(s => s.CompanyEntityId)
            .OnDelete(DeleteBehavior.Restrict); // Or Cascade/SetNull depending on requirements
    }


}