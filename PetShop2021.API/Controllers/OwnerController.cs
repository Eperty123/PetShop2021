using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2021.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        readonly IOwnerService _OwnerService;

        public OwnerController(IOwnerService OwnerService)
        {
            _OwnerService = OwnerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _OwnerService.GetOwners().OfType<Owner>().ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner OwnerBody)
        {
            if (id != OwnerBody.GetId()) return BadRequest("The id doesn't match with the body please.");
            return (Owner)_OwnerService.UpdateOwner(OwnerBody);
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Fuck you! The id is completely wrong.");
            var foundOwner = _OwnerService.GetOwner(id);
            if (foundOwner == null) return BadRequest("That Owner with the desired id doesn't exist.");
            return (Owner)foundOwner;
        }

        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner OwnerBody)
        {
            return (Owner)_OwnerService.AddOwner(OwnerBody);
        }
    }
}
