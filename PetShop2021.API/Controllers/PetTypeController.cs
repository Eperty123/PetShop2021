using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using System.Collections.Generic;

namespace PetShop2021.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetTypeController : ControllerBase
    {
        readonly IPetTypeService _PetTypeService;

        public PetTypeController(IPetTypeService PetTypeService)
        {
            _PetTypeService = PetTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            return _PetTypeService.GetPetTypes();
        }

        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType PetTypeBody)
        {
            if (id != PetTypeBody.GetId()) return BadRequest("The id doesn't match with the body please.");
            return (PetType)_PetTypeService.UpdatePetType(PetTypeBody);
        }

        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            if (id < 1) return BadRequest("Fuck you! The id is completely wrong.");
            var foundPetType = _PetTypeService.GetPetType(id);
            if (foundPetType == null) return BadRequest("That PetType with the desired id doesn't exist.");
            return (PetType)foundPetType;
        }

        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType PetTypeBody)
        {
            return (PetType)_PetTypeService.AddPetType(PetTypeBody);
        }
    }
}
