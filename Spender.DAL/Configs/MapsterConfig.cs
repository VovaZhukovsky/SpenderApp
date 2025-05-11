using Mapster;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Configs;
public class MapsterConfig
{
    public MapsterConfig()
    {
        TypeAdapterConfig<ClientViewModel,Client>.NewConfig();
        TypeAdapterConfig<CurrencyViewModel,Currency>.NewConfig();
        TypeAdapterConfig<CategoryViewModel, Category>.NewConfig();
        TypeAdapterConfig<ExpenseViewModel, Expense>.NewConfig();
        TypeAdapterConfig<IncomeViewModel, Income>.NewConfig();
    }
}