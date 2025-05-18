using Mapster;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Repositories;
public class CurrencyRepository : IRepository<CurrencyViewModel>
{
    private readonly ApplicationContext _dbcontext;
    private bool disposed = false;

    public CurrencyRepository(ApplicationContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<CurrencyViewModel> GetItemList()
    {
        return _dbcontext.Currencies.Select(c => c.Adapt<CurrencyViewModel>());
    }
    public CurrencyViewModel? GetItem(Guid id)
    {
        return _dbcontext.Currencies.Find(id).Adapt<CurrencyViewModel>();
    }
    public void Create(CurrencyViewModel currency)
    {
        _dbcontext.Currencies.Add(currency.Adapt<Currency>());
    }
    public void Update(CurrencyViewModel currency)
    {
        _dbcontext.Currencies.Update(currency.Adapt<Currency>());
    }
    public void Delete(Guid id)
    {
        var currency = _dbcontext.Currencies.Find(id);

        if (currency is not null)
            _dbcontext.Currencies.Remove(currency);
    }
    public void Save()
    {
        _dbcontext.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
        if(disposed)
        {
            if(disposing)
            {
                _dbcontext.Dispose();
            }
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}