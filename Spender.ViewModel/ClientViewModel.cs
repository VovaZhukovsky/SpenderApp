namespace Spender.ViewModel;
public class ClientViewModel
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public string? Mail {get; set;}
    public Guid CurrencyId {get;set;}
}