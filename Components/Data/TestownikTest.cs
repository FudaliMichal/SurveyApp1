using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SurveyApp1.Models;

namespace SurveyApp1.Components.Data;

public class TestownikTest
{
    [Key]
    public int TestId { get; set; }
    public string UserId { get; set; } = null!;
    public string TestTitle { get; set; } = null!;
    public List<TestownikQuestion> TestQuestions { get; set; } = null!;

}