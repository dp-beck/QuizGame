using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.DTOs;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class QuestionService(
    IDbContextFactory<QuizGameDbContext> contextFactory) : IQuestionService
{
    private IDbContextFactory<QuizGameDbContext> _contextFactory = contextFactory;
    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Questions.ToListAsync();
    }

    public async Task<Question?> GetQuestionAsync(int questionId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
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

        await using var context = _contextFactory.CreateDbContext();
        await context.Questions.AddAsync(question);
        await context.SaveChangesAsync();
    }

    public async Task DeleteQuestion(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var question = await context.Questions.FindAsync(id);
        if (question != null) context.Questions.Remove(question);
        await context.SaveChangesAsync();

    }

    public async Task EditQuestion(Question question)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Entry(question).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}