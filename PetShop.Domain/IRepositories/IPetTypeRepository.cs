using PetShop.Core.Models;
using System.Collections.Generic;

namespace PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        // TODO: IPetType CRUD.
        IPetType AddPetType(IPetType petType);
        IPetType CreatePetType(string type);
        IPetType GetPetType(int id);
        IPetType GetPetType(IPetType petType);
        IPetType UpdatePetType(IPetType petType);
        bool DeletePetType(IPetType petType);

        List<PetType> ReadPetTypes();
    }
}
