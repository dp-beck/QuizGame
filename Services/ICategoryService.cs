using QuizGame.Data.DTOs;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public interface ICategoryService
{
    public Task<List<Category>> GetCategories();
    public Task<Category?> GetCategory(int id);
    public Task AddCategory(CategoryDto newCategory);
    public Task DeleteCategory(int id);
}