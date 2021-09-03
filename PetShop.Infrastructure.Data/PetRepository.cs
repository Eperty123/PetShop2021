using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System.Collections.Generic;
using System.Drawing;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        #region Variables
        FakeDB FakeDB;
        #endregion

        #region Constructors
        public PetRepository()
        {
            FakeDB = new FakeDB();
        }

        #endregion

        #region Methods

        public IPet AddPet(IPet pet)
        {
            return FakeDB.AddPet(pet);
        }

        public IPet CreatePet(int id, string name, string type, string color, double price)
        {
            var newPet = new Pet();
            newPet.SetId(id);
            newPet.SetName(name);
            newPet.SetPetType(new PetType(type));
            newPet.SetColor(Color.FromName(color));
            newPet.SetPrice(price);
            return newPet;
        }

        public IPet CreatePet(string name, string type, string color, double price)
        {
            return CreatePet(0, name, type, color, price);
        }

        public IPet CreatePet(string name, IPetType type, Color color, double price)
        {
            var newPet = new Pet();
            newPet.SetName(name);
            newPet.SetPetType(type);
            newPet.SetColor(color);
            newPet.SetPrice(price);
            return newPet;
        }

        public bool DeletePet(IPet pet)
        {
            return FakeDB.DeletePet(pet);
        }

        public IEnumerable<IPet> GetPets()
        {
            return FakeDB.GetPets();
        }

        public IPet GetPet(int id)
        {
            return FakeDB.GetPet(id);
        }

        public IPet GetPet(IPet pet)
        {
            return FakeDB.GetPet(pet);
        }

        public IPet UpdatePet(IPet pet)
        {
            return FakeDB.UpdatePet(pet);
        }

        #endregion
    }
}
