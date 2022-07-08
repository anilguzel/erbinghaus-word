using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseNpgsql(@"User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=ebbinghaus;Integrated Security=true;Pooling=true;");
    }

    public DbSet<Word> word { get; set; }
    public DbSet<Sentence> sentence { get; set; }
}