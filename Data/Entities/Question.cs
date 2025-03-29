using System.ComponentModel.DataAnnotations;

namespace QuizGame.Data.Entities;

public class Question
{
    [Key]
    public int Id { get; set; }
    public required string QuestionText { get; set; }
    public required Answer Answer { get; set; }
    public string? Category { get; set; }
    public Answer[]? MultipleChoices { get; set; }
}