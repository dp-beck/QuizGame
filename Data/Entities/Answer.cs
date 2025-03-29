using System.ComponentModel.DataAnnotations;

namespace QuizGame.Data.Entities;

public class Answer
{
    [Key]
    public int Id { get; set; }
    public required string AnswerText { get; set; }
}