﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public DbSet<QuestionEntity> Questions { get; set; }

    public DbSet<CompanyEntity> Companies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CompanyEntity>().ToTable("Companies");

        modelBuilder.Entity<SquadEntity>()
            .HasOne(s => s.Company)
            .WithMany(c => c.Squads)
            .HasForeignKey(s => s.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); // Or Cascade/SetNull depending on requirements
    }


}