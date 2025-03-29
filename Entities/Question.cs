namespace QuizGame.Entities;

public class Question
{
    public int Id { get; set; }
    public required string QuestionText { get; set; }
    public required Answer Answer { get; set; }
    public string? Category { get; set; }
    public Answer[]? MultipleChoices { get; set; }
}