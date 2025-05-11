using Spender.ViewModel;

namespace Spender.DAL.Models;

public class Income : IncomeViewModel
{   
    public required virtual Client Client {get; set;}
    public required virtual Category Category { get; set;}
    public required virtual Currency Currency { get; set;}
}