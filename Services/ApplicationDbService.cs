using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SurveyApp1.Components.Data;
using SurveyApp1.Models;
using SurveyApp1.Data;


namespace SurveyApp1.Services;


public class ApplicationDbService
{
    private readonly ApplicationDbContext _dbContext;


    public ApplicationDbService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task DbInsertTestAsync(TestownikTest testEntity)
    {
        _dbContext.Tests.Add(testEntity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<List<TestownikTestModel>> TestContentsAsync(string userid)
    {
        var testList = new List<TestownikTestModel>();
        
        var test = await _dbContext.Tests
            .AsNoTracking()
            .Include(x => x.TestQuestions)
            .ThenInclude(x => x.Answers)
            .Where(x => x.UserId == userid)
            .ToListAsync();

        foreach (var testEntity in test)
        {
            var temp = testEntity.ToModel();
            testList.Add(temp);
        }

        foreach (var t in testList)
        {
            Console.WriteLine(t.TestTitle);
        }
        
        return testList;
       
    }
    
}