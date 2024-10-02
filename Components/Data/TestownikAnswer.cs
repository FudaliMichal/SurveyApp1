using System.ComponentModel.DataAnnotations;

namespace SurveyApp1.Components.Data;

public class TestownikAnswer
{
    [Key]
    public int AnswerId { get; set; }
    
    public int QuestionId { get; set; }
    public required string AnswerText { get; set; }
    
    public required bool IsCorrectAnswer { get; set; }
}