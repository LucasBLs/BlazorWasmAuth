using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BlazorWasmAuth.Api.Models;

namespace BlazorWasmAuth.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext
    <User, 
    IdentityRole<long>, 
    long,
    IdentityUserClaim<long>,
    IdentityUserRole<long>,
    IdentityUserLogin<long>,
    IdentityRoleClaim<long>,
    IdentityUserToken<long>>(options)
{
    //public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<IncomesAndExpenses>().HasNoKey().ToView("vwGetIncomesAndExpenses");
        //modelBuilder.Entity<ExpensesByCategory>().HasNoKey().ToView("vwGetExpensesByCategory");
        //modelBuilder.Entity<IncomesByCategory>().HasNoKey().ToView("vwGetIncomesByCategory");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName($"BlazorWasmAuth_{tableName.Substring(6)}");
            }
        }
    }
}