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
    public class ClientController : Controller
    {
        private readonly IRepository<ClientViewModel> _repo;
        public ClientController(IRepository<ClientViewModel> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult Create([FromBody] ClientViewModel client)
        {
            _repo.Create(client);
            _repo.Save();
            return StatusCode(200,client);
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return StatusCode(200, _repo.GetItem(id));
        }
        
        [HttpGet("{mail}/mail")]
        public ActionResult GetByMail([FromRoute] string mail)
        {
            return StatusCode(200, _repo.GetItemList().Where(c => c.Mail == mail).FirstOrDefault());
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