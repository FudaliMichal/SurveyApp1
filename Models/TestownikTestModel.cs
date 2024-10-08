namespace SurveyApp1.Models;

public class TestownikTestModel
{
    public TestownikTestModel(List<TestownikQuestionModel> testQuestions)
    {
        TestQuestions = testQuestions;
        TestTitle = string.Empty;
    }

    

    public string TestTitle { get; set; }
    public List<TestownikQuestionModel> TestQuestions { get; set; }
    
}