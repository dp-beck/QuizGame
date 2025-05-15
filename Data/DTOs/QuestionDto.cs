namespace QuizGame.Data.DTOs;

public class QuestionDto
{
    public required string QuestionText { get; set; }

    public required string Answer { get; set; }
    
    public int CategoryId { get; set; }

    public string[] WrongChoices { get; set; } = new string[3];
}