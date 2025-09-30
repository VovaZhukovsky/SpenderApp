using Mapster;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.ViewModel;

namespace Spender.DAL.Repositories;
public class ClientRepository : IRepository<ClientViewModel>
{
    private readonly ApplicationContext _dbcontext;
    private bool disposed = false;

    public ClientRepository(ApplicationContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public IEnumerable<ClientViewModel> GetItemList()
    {
        return _dbcontext.Clients.Select(c => c.Adapt<ClientViewModel>());
    }
    public ClientViewModel? GetItem(Guid id)
    {
        return _dbcontext.Clients.Find(id).Adapt<ClientViewModel>();
    }
    public ClientViewModel Create(ClientViewModel client)
    {
        return _dbcontext.Clients.Add(client.Adapt<Client>()).Entity.Adapt<ClientViewModel>();
    }
    public void Update(ClientViewModel client)
    {
        _dbcontext.Clients.Update(client.Adapt<Client>());
    }
    public void Delete(Guid id)
    {
        var client = _dbcontext.Clients.Find(id);

        if (client is not null)
            _dbcontext.Clients.Remove(client);
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