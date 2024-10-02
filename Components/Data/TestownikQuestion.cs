using System.ComponentModel.DataAnnotations;
using SurveyApp1.Models;

namespace SurveyApp1.Components.Data;

public class TestownikQuestion
{
    [Key]
    public int QuestionId { get; set; }
    
    public int TestId { get; set; }
    
    public string QuestionText { get; set; } = null!;

    public List<TestownikAnswer> Answers { get; set; } = null!;
}