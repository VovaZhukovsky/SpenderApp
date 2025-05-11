using Spender.ViewModel;

namespace Spender.DAL.Models;

public class Category : CategoryViewModel
{
    public virtual ICollection<Expense> Expenses {get; set;}
    public virtual ICollection<Income> Incomes {get; set;}
    public required virtual Client Client {get;set;}
    public Category()
    {
        Expenses = new HashSet<Expense>();
        Incomes = new HashSet<Income>();
    }
        
}