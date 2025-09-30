using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Spender.DAL;
using Spender.DAL.Interfaces;
using Spender.DAL.Models;
using Spender.DAL.Repositories;
using Spender.ViewModel;


namespace Spender.Api.Controllers
{
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private readonly IRepository<CurrencyViewModel>  _repo;
        public CurrencyController(IRepository<CurrencyViewModel> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CurrencyViewModel currency)
        {
            var response = _repo.Create(currency);
            _repo.Save();
            return StatusCode(200,response);
        }
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return StatusCode(200,_repo.GetItem(id));
        }
        [HttpGet("{name}/name")]
        public ActionResult Get(string name)
        {
            return StatusCode(200, _repo.GetItemList().Where(c => c.Name == name).FirstOrDefault());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            _repo.Save();
            return StatusCode(201,null);
        }


    }
}