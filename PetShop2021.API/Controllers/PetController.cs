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

        //[HttpGet]
        //public ActionResult<IEnumerable<Pet>> Get()
        //{
        //    return _PetService.GetPets().OfType<Pet>().ToList();
        //}

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet petBody)
        {
            if (Get(id) == null)
                throw new System.Exception("Bruh! That pet doesn´t exist.");

            return Create(petBody);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return (Pet)_PetService.GetPet(id);
        }

        [HttpPost]
        public ActionResult<Pet> Create([FromBody] Pet petBody)
        {
            return (Pet)_PetService.AddPet(petBody);
        }
    }
}
