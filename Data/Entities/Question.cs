using System.ComponentModel.DataAnnotations;

namespace QuizGame.Data.Entities;

public class Question
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public required string QuestionText { get; set; }

    [MaxLength(100)]
    public required string Answer { get; set; }
    
    [MaxLength(50)]
    public Category? Category { get; set; }

    public string[] WrongChoices { get; set; } = new string[3];
}