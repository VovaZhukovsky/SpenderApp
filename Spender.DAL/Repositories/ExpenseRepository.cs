using Mapster;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Repositories;
public class ExpenseRepository : IRepository<ExpenseViewModel>
{
    private readonly ApplicationContext _dbcontext;
    private bool disposed = false;

    public ExpenseRepository(ApplicationContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<ExpenseViewModel> GetItemList()
    {
        return _dbcontext.Expenses.Select(c => c.Adapt<ExpenseViewModel>());
    }
    public ExpenseViewModel? GetItem(Guid id)
    {
        return _dbcontext.Expenses.Find(id).Adapt<ExpenseViewModel>();
    }
    public ExpenseViewModel Create(ExpenseViewModel expense)
    {
        return _dbcontext.Expenses.Add(expense.Adapt<Expense>()).Entity.Adapt<ExpenseViewModel>();
    }
    public void Update(ExpenseViewModel expense)
    {
        _dbcontext.Expenses.Update(expense.Adapt<Expense>());
    }
    public void Delete(Guid id)
    {
        var expense = _dbcontext.Expenses.Find(id);

        if (expense is not null)
            _dbcontext.Expenses.Remove(expense);
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