using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System.Collections.Generic;
using System.Drawing;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        #region Variables

        readonly FakeDB FakeDB;

        #endregion

        #region Constructors

        public PetRepository(FakeDB fakeDB)
        {
            FakeDB = fakeDB;
            InitData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add test data.
        /// </summary>
        void InitData()
        {

            #region Pet test data

            var testPets = new List<IPet>()
            {
                CreatePet("Haru", "Cat", "Black", 150),
                CreatePet("Tatsuya", "Dog", "Blue", 200),
                CreatePet("Eleina", "Goat", "Cyan", 350),
                CreatePet("Elei", "Goat", "Cyan", 3850),
                CreatePet("Azusa", "Goat", "Cyan", 3506),
                CreatePet("Erika", "Goat", "Cyan", 3590),
            };

            AddPets(testPets);

            #endregion
        }

        public void AddPets(params IPet[] pets)
        {
            for (int i = 0; i < pets.Length; i++)
                AddPet(pets[i]);
        }

        public void AddPets(IEnumerable<IPet> pets)
        {
            var _pets = new List<IPet>(pets);
            for (int i = 0; i < _pets.Count; i++)
                AddPet(_pets[i]);
        }

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

        public List<Pet> ReadPets()
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
