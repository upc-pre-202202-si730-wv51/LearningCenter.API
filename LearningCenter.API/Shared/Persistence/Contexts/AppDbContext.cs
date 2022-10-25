using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutorial> Tutorials { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Category Entity Mapping Configuration
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(p => p.Name)
            .IsRequired().HasMaxLength(30);
        
        
        
        // Tutorial Entity Mapping Configuration

        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Tutorial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(p => p.Description).HasMaxLength(120);

        // Relationships

        builder.Entity<Category>()
            .HasMany(p => p.Tutorials)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        
        
        // TutorialTag Entity Mapping Configuration
        builder.Entity<TutorialTag>()
            .HasKey(p => new { p.TutorialId, p.TagId });
        builder.Entity<TutorialTag>().ToTable("TutorialTags");
        builder.Entity<TutorialTag>()
            .HasOne(p => p.Tutorial)
            .WithMany(p => p.TutorialTags)
            .HasForeignKey(p => p.TutorialId);

        builder.Entity<TutorialTag>()
            .HasOne(p => p.Tag)
            .WithMany(p => p.TutorialTags)
            .HasForeignKey(p => p.TagId);
        
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}