using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.DTOs;
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

    public async Task AddCategory(CategoryDto newCategory)
    {
        Category category = new Category
        {
            Name = newCategory.Name,
        };
        
        await using var context = _contextFactory.CreateDbContext();
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var category = await context.Categories.FindAsync(id);
        if (category != null) context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
}