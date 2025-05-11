using Serilog;
using Microsoft.EntityFrameworkCore;
using Spender.DAL;
using Spender.DAL.Interfaces;
using Spender.DAL.Repositories;
using Spender.DAL.Configs;
using Spender.ViewModel;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

try
{
    Log.Information("Application started");
    builder.Services.AddSingleton(Log.Logger);
    builder.Services.AddScoped<MapsterConfig>();
    builder.Services.AddScoped<IRepository<ClientViewModel>, ClientRepository>();   
    builder.Services.AddScoped<IRepository<CurrencyViewModel>, CurrencyRepository>();
    builder.Services.AddScoped<IRepository<CategoryViewModel>, CategoryRepository>();
    builder.Services.AddScoped<IRepository<ExpenseViewModel>, ExpenseRepository>();
    builder.Services.AddScoped<IRepository<IncomeViewModel>, IncomeRepository>();
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=spenderdb;Username=postgres;Password=12345",
        providerOptions => providerOptions.EnableRetryOnFailure()), ServiceLifetime.Transient);
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        dataContext.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{  
    Log.Error(ex, "The Application failed to start.");
}
finally
{
    Log.CloseAndFlush();
}
public partial class Program { }
