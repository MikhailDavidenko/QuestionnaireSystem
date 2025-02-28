using Microsoft.EntityFrameworkCore;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Engine;

public sealed class AppDbContext : DbContext
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    
    public DbSet<Result> Results { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSnakeCaseNamingConvention();// Все имена таблиц и столбцов будут в SnakeCase
}