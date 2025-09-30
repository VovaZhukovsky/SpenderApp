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
    public class ExpenseController : Controller
    {
        private readonly IRepository<ExpenseViewModel> _repo;
        public ExpenseController(IRepository<ExpenseViewModel> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Create([FromBody] ExpenseViewModel expense)
        {
            var response = _repo.Create(expense);
            _repo.Save();
            return StatusCode(200,response);
        }
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return StatusCode(200,_repo.GetItem(id));
        }

        [HttpGet("{clientid}/client")]
        public ActionResult GetByClientId(Guid clientid)
        {
            return StatusCode(200,_repo.GetItemList().Where(e => e.ClientId == clientid));
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