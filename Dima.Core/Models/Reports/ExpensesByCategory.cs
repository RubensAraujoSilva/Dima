namespace Dima.Core.Models.Reports;

//Despesas por Categorias 
public record ExpensesByCategory(string UserId, string Category, int Year, decimal Expenses);
