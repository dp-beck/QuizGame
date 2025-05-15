using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class CategoryService(IDbContextFactory<QuizGameDbContext> contextFactory) : ICategoryService
{
    private IDbContextFactory<QuizGameDbContext> _contextFactory = contextFactory;

    public async Task<List<Category>> GetCategories()
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategory(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        return await context.Categories.FindAsync(id);
    }
}