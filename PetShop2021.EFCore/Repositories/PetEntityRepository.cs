using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.Infrastructure.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PetShop2021.EFCore.Repositories
{
    public class PetEntityRepository : IPetRepository
    {
        #region Variables

        readonly PetShopDbContext _PetShopDbContext;

        #endregion

        #region Constructors

        public PetEntityRepository(PetShopDbContext petShopDbContext)
        {
            _PetShopDbContext = petShopDbContext;
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

        /// <summary>
        /// Add an array of pets to the pet repository.
        /// </summary>
        /// <param name="pets">The pets to add.</param>
        public void AddPets(params IPet[] pets)
        {
            for (int i = 0; i < pets.Length; i++)
                AddPet(pets[i]);
        }

        /// <summary>
        /// Add an array of pets to the pet repository.
        /// </summary>
        /// <param name="pets">The pets to add.</param>
        public void AddPets(IEnumerable<IPet> pets)
        {
            var _pets = new List<IPet>(pets);
            for (int i = 0; i < _pets.Count; i++)
                AddPet(_pets[i]);
        }

        public IPet AddPet(IPet pet)
        {
            var addedPet = _PetShopDbContext.Pets.Add((Pet)pet).Entity;
            _PetShopDbContext.SaveChanges();
            return addedPet;
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
            var deletedPet = _PetShopDbContext.Pets.Remove((Pet)pet).Entity;
            _PetShopDbContext.SaveChanges();
            return deletedPet != null;
        }

        public List<Pet> ReadPets()
        {
            return _PetShopDbContext.Pets.ToList();
        }

        public IPet GetPet(int id)
        {
            return ReadPets().FirstOrDefault(x => x.GetId().Equals(id));
        }

        public IPet GetPet(IPet pet)
        {
            return GetPet(pet.GetId());
        }

        public IPet UpdatePet(IPet pet)
        {
            var updatedPet = _PetShopDbContext.Pets.Update((Pet)pet).Entity;
            _PetShopDbContext.SaveChanges();
            return updatedPet;
        }

        #endregion
    }
}
