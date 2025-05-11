namespace Spender.ViewModel;
public class IncomeViewModel
{
    public Guid Id {get; set;}
    public DateOnly Date {get; set;}
    public TimeOnly Time {get; set;}
    public decimal Amount {get; set;}
    public Guid CurrencyId {get; set;}
    public Guid CategoryId {get; set;}
    public Guid ClientId {get; set;}
    public string? Description {get; set;}

}