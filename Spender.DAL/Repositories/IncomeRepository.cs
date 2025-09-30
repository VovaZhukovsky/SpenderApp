using Mapster;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Repositories;
public class IncomeRepository : IRepository<IncomeViewModel>
{
    private readonly ApplicationContext _dbcontext;
    private bool disposed = false;

    public IncomeRepository(ApplicationContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<IncomeViewModel> GetItemList()
    {
        return _dbcontext.Incomes.Select(c => c.Adapt<IncomeViewModel>());
    }
    public IncomeViewModel? GetItem(Guid id)
    {
        return _dbcontext.Incomes.Find(id).Adapt<IncomeViewModel>();
    }
    public IncomeViewModel Create(IncomeViewModel income)
    {
        return _dbcontext.Incomes.Add(income.Adapt<Income>()).Entity.Adapt<IncomeViewModel>();
    }
    public void Update(IncomeViewModel income)
    {
        _dbcontext.Incomes.Update(income.Adapt<Income>());
    }
    public void Delete(Guid id)
    {
        var income = _dbcontext.Incomes.Find(id);

        if (income is not null)
            _dbcontext.Incomes.Remove(income);
    }
    public void Save()
    {
        _dbcontext.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
        if(!disposed)
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