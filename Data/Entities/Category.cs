using System.ComponentModel.DataAnnotations;

namespace QuizGame.Data.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}