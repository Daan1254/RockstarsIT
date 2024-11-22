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

    public DbSet<Company> Companies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>().ToTable("Companies");

        modelBuilder.Entity<SquadEntity>()
            .HasOne(s => s.Company)
            .WithMany(c => c.Squads)
            .HasForeignKey(s => s.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); // Or Cascade/SetNull depending on requirements
    }


}