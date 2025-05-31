using QuizGame.Data.DTOs;
using QuizGame.Data.Entities;

namespace QuizGame.Services;

public interface IQuestionService
{
    public Task<List<Question>> GetAllQuestionsAsync();
    public Task AddQuestion(QuestionDto questionDto);
    public Task DeleteQuestion(int id);
}