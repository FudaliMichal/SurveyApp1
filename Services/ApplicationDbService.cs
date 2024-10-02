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
    
    
    
    
}