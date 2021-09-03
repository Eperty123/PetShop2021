using PetShop.Core.Models;
using System.Collections.Generic;

namespace PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        // TODO: IPetType CRUD.
        IPetType AddPetType(IPetType petType);
        IPetType CreatePetType(string name);
        IPetType GetPetType(int id);
        IPetType GetPetType(string typeName);
        IPetType GetPetType(IPetType petType);
        IPetType UpdatePetType(IPetType petType);
        bool DeletePetType(IPetType petType);

        List<PetType> GetPetTypes();
    }
}
