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
    public class CategoryController : Controller
    {
        private readonly IRepository<CategoryViewModel> _repo;
        public CategoryController(IRepository<CategoryViewModel> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CategoryViewModel category)
        {
            var response = _repo.Create(category);
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
            return StatusCode(200,_repo.GetItemList().Where(c => c.ClientId == clientid));
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