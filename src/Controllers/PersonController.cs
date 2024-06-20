using Microsoft.AspNetCore.Mvc;
using Mongo_API.Models;
using Mongo_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mongo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService? _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return _personService!.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetPerson")]
        public ActionResult<Person> Get(string id)
        {
            var person = _personService!.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            _personService!.Create(person);

            return CreatedAtRoute("GetPerson", new { id = person.Id!.ToString() }, person);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Person personIn)
        {
            var person = _personService!.Get(id);
            
            if (person == null)
            {
                return NotFound();
            }
            _personService.Update(id, personIn);
            
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var person = _personService!.Get(id);

            if (person == null)
            { 
                return NotFound();
            } 

            _personService.Remove(person.Id!);
            return NoContent();
        }
    }
}