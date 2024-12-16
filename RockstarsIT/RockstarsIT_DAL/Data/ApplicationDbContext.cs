using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockstarsIT_DAL.Entities;

namespace RockstarsIT_DAL.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<SurveyEntity> Surveys { get; set; }
    public DbSet<SquadEntity> Squads { get; set; }

    public DbSet<AnswerEntity> Answers { get; set; }

    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<EmailEntity> Emails { get; set; }
    public DbSet<CompletedSurveyEntity> CompletedSurveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CompanyEntity>().ToTable("Companies");

        modelBuilder.Entity<SquadEntity>()
            .HasOne(s => s.Company)
            .WithMany(c => c.Squads)
            .HasForeignKey(s => s.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); // Or Cascade/SetNull depending on requirements
        
        modelBuilder.Entity<SquadEntity>()
            .HasMany(s => s.Users)
            .WithOne(s => s.Squad)
            .HasForeignKey(s => s.SquadId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<UserEntity>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<string>("Discriminator")
            .HasValue("UserEntity");
        
        modelBuilder.Entity<SquadEntity>().HasQueryFilter(s => s.DeletedAt == null);
        modelBuilder.Entity<SurveyEntity>().HasQueryFilter(s => s.DeletedAt == null);
        modelBuilder.Entity<QuestionEntity>().HasQueryFilter(q => q.DeletedAt == null);

        modelBuilder.Entity<AnswerEntity>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<SurveyEntity>()
            .HasMany(s => s.Squads)
            .WithMany(sq => sq.Surveys)
            .UsingEntity(j => j.ToTable("Squad_Surveys"));

        modelBuilder.Entity<CompletedSurveyEntity>()
            .HasOne(cs => cs.Survey)
            .WithMany(s => s.CompletedSurveys)
            .HasForeignKey(cs => cs.SurveyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CompletedSurveyEntity>()
            .HasOne(cs => cs.Squad)
            .WithMany(s => s.CompletedSurveys)
            .HasForeignKey(cs => cs.SquadId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EmailEntity>()
            .HasOne(e => e.Survey)
            .WithMany(s => s.Emails)
            .HasForeignKey(e => e.SurveyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EmailEntity>()
            .HasOne(e => e.User)
            .WithMany(u => u.Emails)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }


}