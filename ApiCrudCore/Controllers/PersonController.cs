using ApiCrudCore.Models;
using ApiCrudCore.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudCore.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IRepository<Person, int> iRepository;
        public PersonController(IRepository<Person, int> repo)
        {
            iRepository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dbResult = await iRepository.GetAll();
            return Json(dbResult);
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return iRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Person person)
        {
            iRepository.Add(person);
        }

        [HttpPut]
        public void Put([FromBody]Person person)
        {

            iRepository.Update(person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            iRepository.Delete(id);
        }

    }
}
