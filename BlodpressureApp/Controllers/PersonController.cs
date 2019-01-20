using BloodpressureApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BloodpressureApp.Controllers
{
    public class PersonController : Controller
    {
        private BloodPressureInfoContext _ctx;

        public PersonController(BloodPressureInfoContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("api/Person")]
        public IActionResult GetPerson()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personList = _ctx.Persons.AsParallel();
            return Ok(personList);
        }

        [HttpGet]
        [Route("api/Person/{id}", Name ="GetPersonId")]
        public IActionResult GetPerson(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var person = _ctx.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return BadRequest("Personen finns inte");
            
            return Ok(person);
        }
    }
}