using Dima.Api.Models;
using Dima.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Dima.Core.Models.Reports;

namespace Dima.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext
        <
            User, 
            IdentityRole<long>, 
            long, 
            IdentityUserClaim<long>, 
            IdentityUserRole<long>, 
            IdentityUserLogin<long>, 
            IdentityRoleClaim<long>,
            IdentityUserToken<long>
        >(options)
    {


        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        //Mapeamento das Views
        public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; } = null!;
        public DbSet<IncomesByCategory> IncomesByCategories { get; set; } = null!;
        public DbSet<ExpensesByCategory> ExpensesByCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Mapeamento das Views
            modelBuilder.Entity<IncomesAndExpenses>()
                .HasNoKey()
                .ToView("vwGetIncomesAndExpenses");
            
            modelBuilder.Entity<IncomesByCategory>()
                .HasNoKey()
                .ToView("vwGetIncomesByCategory");
            
            modelBuilder.Entity<ExpensesByCategory>()
                .HasNoKey()
                .ToView("vwGetExpensesByCategory");
            
            // Configuração para IdentityPasskeyData
            modelBuilder.Entity<IdentityPasskeyData>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("IdentityPasskeyData");
            });

        }

    }
}



