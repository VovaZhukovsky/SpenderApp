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
    public class IncomeController : Controller
    {
        private readonly IRepository<IncomeViewModel> _repo;
        public IncomeController(IRepository<IncomeViewModel> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Create([FromBody] IncomeViewModel income)
        {
            _repo.Create(income);
            _repo.Save();
            return StatusCode(200,income);
        }
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return StatusCode(200,_repo.GetItem(id));
        }

        [HttpGet("{clientid}/client")]
        public ActionResult GetByClientId(Guid clientid)
        {
            return StatusCode(200,_repo.GetItemList().Where(i => i.ClientId == clientid).FirstOrDefault());
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