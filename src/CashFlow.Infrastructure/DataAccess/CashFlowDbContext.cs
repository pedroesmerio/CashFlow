using CashFlow.Domain.Expense;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=G@t3c!;";
        var serverVersion = new MySqlServerVersion(new Version(9, 0, 1));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
