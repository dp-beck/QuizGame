using Microsoft.EntityFrameworkCore;
using QuizGame.Data;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public class QuestionService(IDbContextFactory<QuizGameDbContext> contextFactory)
{
    private IDbContextFactory<QuizGameDbContext> _contextFactory = contextFactory;

    public void AddQuestion(Question question)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Questions.Add(question);
    }
}