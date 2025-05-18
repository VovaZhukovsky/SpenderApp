using Mapster;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Repositories;
public class CategoryRepository : IRepository<CategoryViewModel>
{
    private readonly ApplicationContext _dbcontext;
    private bool disposed = false;

    public CategoryRepository(ApplicationContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<CategoryViewModel> GetItemList()
    {
        return _dbcontext.Categories.Select(c => c.Adapt<CategoryViewModel>());
    }
    public CategoryViewModel? GetItem(Guid id)
    {
        return _dbcontext.Categories.Find(id).Adapt<CategoryViewModel>();
    }
    public void Create(CategoryViewModel category)
    {
        _dbcontext.Categories.Add(category.Adapt<Category>());
    }
    public void Update(CategoryViewModel category)
    {
        _dbcontext.Categories.Update(category.Adapt<Category>());
    }
    public void Delete(Guid id)
    {
        var category = _dbcontext.Categories.Find(id);

        if (category is not null)
            _dbcontext.Categories.Remove(category);
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