using System.Text.RegularExpressions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using SurveyApp1.Components.Data;
using SurveyApp1.Data;
using SurveyApp1.Models;

namespace SurveyApp1.Services;

public class TestFileParserService
{
    
    
    public async Task<TestownikTest> ParseFileAsync(string dir, string? curUser, string testName)
    {
        var dirInfo = new DirectoryInfo(dir);
        var files = dirInfo.EnumerateFiles("*.txt", SearchOption.AllDirectories)
            .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

        var questions = new List<TestownikQuestion>{};

        foreach (var file in files)
        {
            var question = await AssembleQuestion(file);
            //wyswietlanie zczytanych plikow w konsoli
            // CWQuestions(question.ToModel());
            
            questions.Add(question);
        }
        
        var test = new TestownikTest()
        {
            TestQuestions = questions,
            TestTitle = testName,
            UserId = curUser,
            
        };
        return test;
    }
    
    private async Task<TestownikQuestion> AssembleQuestion(FileInfo file)
    {

        var fileName = file.FullName;
        var fileContents = await File.ReadAllTextAsync(fileName);
        
        var pattern = @"QQ([01]+)";
        var match = Regex.Match(fileContents, pattern);

        var answers = new List<TestownikAnswer>();
        
        if (match.Success)
        {
            var binaryAnswers = match.Groups[1].Value;

            foreach (var c in binaryAnswers)
            {
                TestownikAnswer answer = new()
                {
                    AnswerText = string.Empty,
                    IsCorrectAnswer = c =='1'
                };
                
                answers.Add(answer);
            }
        }
        else Console.WriteLine("File is not valid!");

        
        var allLines = fileContents.Split('\n');

        
        var questionText = allLines[1];
        
        for (var i = 0; i < answers.Count; i++)
        {
            answers[i].AnswerText = allLines[i+2];
        }

        TestownikQuestion question = new()
        {
            QuestionText = questionText,
            Answers = answers,
        };
        
        return question;
    }
    
    private void CWQuestions(TestownikQuestionModel question)
    {
        Console.WriteLine($"\n{question.QuestionText}");
        foreach (var lineAnswer in question.Answers)
        {
            Console.WriteLine(lineAnswer.AnswerText);
            Console.WriteLine($"\t {lineAnswer.IsCorrectAnswer}");
        }
    }
    
}

