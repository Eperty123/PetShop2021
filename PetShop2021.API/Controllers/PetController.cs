using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2021.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        readonly IPetService _PetService;

        public PetController(IPetService petService)
        {
            _PetService = petService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _PetService.GetPets().OfType<Pet>().ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet petBody)
        {
            if (id != petBody.GetId()) return BadRequest("The id doesn't match with the body please.");
            return (Pet)_PetService.UpdatePet(petBody);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Fuck you! The id is completely wrong.");
            var foundPet = _PetService.GetPet(id);
            if (foundPet == null) return BadRequest("That pet with the desired id doesn't exist.");
            return (Pet)foundPet;
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet petBody)
        {
            return (Pet)_PetService.AddPet(petBody);
        }
    }
}
