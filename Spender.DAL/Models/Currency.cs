using Spender.ViewModel;

namespace Spender.DAL.Models;

public class Currency : CurrencyViewModel
{
    public required virtual ICollection<Expense> Expenses {get; set;}
    public required virtual ICollection<Income> Incomes {get; set;}
    public required virtual ICollection<Client> Clients {get;set;}
    public Currency()
    {
        Expenses = new HashSet<Expense>();
        Incomes = new HashSet<Income>();
        Clients = new HashSet<Client>();
    }
}