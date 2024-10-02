using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp1.Components.Data;

namespace SurveyApp1.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<TestownikTest> Tests { get; set; } = default!;
    
    public DbSet<TestownikQuestion> Questions { get; set; } = default!;
    
    public DbSet<TestownikAnswer> Answers { get; set; } = default!;
}