using Microsoft.EntityFrameworkCore;
using QuizGame.Data.Entities;

namespace QuizGame.Data;

public class QuizGameDbContext : DbContext
{
    public QuizGameDbContext(DbContextOptions<QuizGameDbContext> options)
        : base(options)
    {
    
    }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}