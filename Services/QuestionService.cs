using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class QuestionService(IDbContextFactory<QuizGameDbContext> contextFactory)
{
    private IDbContextFactory<QuizGameDbContext> _contextFactory = contextFactory;

    public async Task AddQuestion(Question question)
    {
        await using var context = _contextFactory.CreateDbContext();
        await context.Questions.AddAsync(question);
        await context.SaveChangesAsync();
    }
}