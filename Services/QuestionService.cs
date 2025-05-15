using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.DTOs;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class QuestionService(
    IDbContextFactory<QuizGameDbContext> contextFactory,
    ICategoryService categoryService)
{
    public async Task AddQuestion(QuestionDto questionDto)
    {
        var category = await categoryService.GetCategory(questionDto.CategoryId);
        
        Question question = new Question
        {
            Answer = questionDto.Answer,
            QuestionText = questionDto.QuestionText,
            Category = category,
            WrongChoices = questionDto.WrongChoices
        };
        
        await using var context = contextFactory.CreateDbContext();
        await context.Questions.AddAsync(question);
        await context.SaveChangesAsync();
    }
}