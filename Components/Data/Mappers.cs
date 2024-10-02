
using SurveyApp1.Models;

namespace SurveyApp1.Components.Data;



public static class Mappers
{
    public static TestownikAnswerModel ToModel(this TestownikAnswer testownikAnswer)
    {
        return new TestownikAnswerModel
        {
            AnswerText = testownikAnswer.AnswerText,
            IsCorrectAnswer = testownikAnswer.IsCorrectAnswer,
        };
    }
    
    public static TestownikQuestionModel ToModel(this TestownikQuestion testownikQuestion)
    {
        return new TestownikQuestionModel
        {
            QuestionText = testownikQuestion.QuestionText,
            Answers = testownikQuestion.Answers.Select(x => x.ToModel()).ToList(),
        };
    }
}