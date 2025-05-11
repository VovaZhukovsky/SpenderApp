using Spender.ViewModel;

namespace Spender.DAL.Models;
public class Expense: ExpenseViewModel
{
    public required virtual Client Client {get; set;}
    public required virtual Category Category { get; set;}
    public required virtual Currency Currency { get; set;}
}