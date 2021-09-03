using PetShop.Core.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        IPet AddPet(IPet pet);
        IPet CreatePet(string name, string type, string color, double price);
        IPet CreatePet(string name, IPetType type, Color color, double price);
        IPet GetPet(int id);
        IPet GetPet(IPet pet);
        IPet UpdatePet(IPet pet);
        bool DeletePet(IPet pet);

        List<Pet> ReadPets();
    }
}
