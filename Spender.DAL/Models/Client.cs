using System.Runtime.InteropServices.Marshalling;
using Spender.ViewModel;

namespace Spender.DAL.Models;

public class Client : ClientViewModel
{
    public virtual ICollection<Expense> Expenses {get; set;}
    public virtual ICollection<Income> Incomes {get; set;}
    public virtual ICollection<Category> Categories {get;set;}
    public required virtual Currency Currency {get;set;}

    public Client()
    {
        Expenses = new HashSet<Expense>();
        Incomes = new HashSet<Income>();
        Categories = new HashSet<Category>();
    }
}