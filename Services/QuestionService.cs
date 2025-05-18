using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.DTOs;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class QuestionService(
    IDbContextFactory<QuizGameDbContext> contextFactory)
{
    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Questions.ToListAsync();
    }
    public async Task AddQuestion(QuestionDto questionDto)
    {
        Question question = new Question
        {
            Answer = questionDto.Answer,
            QuestionText = questionDto.QuestionText,
            WrongChoices = questionDto.WrongChoices,
            CategoryId = questionDto.CategoryId,
        };

        await using var context = contextFactory.CreateDbContext();
        await context.Questions.AddAsync(question);
        await context.SaveChangesAsync();
    }
}