using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        #region Variables

        readonly PetShopDbContext _PetShopDbContext;

        #endregion

        #region Constructors
        public PetTypeRepository(PetShopDbContext petShopDbContext)
        {
            _PetShopDbContext = petShopDbContext;
            InitData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add test data.
        /// </summary>
        void InitData()
        {

            #region Pet type test data

            var testPets = new List<IPetType>()
            {
                CreatePetType("Cat"),
                CreatePetType("Dog"),
                CreatePetType("Goat"),
            };

            AddPetTypes(testPets);

            #endregion

        }

        /// <summary>
        /// Add an array of pet types to the pet repository.
        /// </summary>
        /// <param name="pets">The pet types to add.</param>
        public void AddPetTypes(params IPetType[] pets)
        {
            for (int i = 0; i < pets.Length; i++)
                AddPetType(pets[i]);
        }

        /// <summary>
        /// Add an array of pet types to the pet repository.
        /// </summary>
        /// <param name="pets">The pet types to add.</param>
        public void AddPetTypes(IEnumerable<IPetType> pets)
        {
            var _pets = new List<IPetType>(pets);
            for (int i = 0; i < _pets.Count; i++)
                AddPetType(_pets[i]);
        }

        public IPetType AddPetType(IPetType petType)
        {
            var addedPetType = _PetShopDbContext.PetTypes.Add((PetType)petType).Entity;
            _PetShopDbContext.SaveChanges();
            return addedPetType;
        }

        public IPetType CreatePetType(string type)
        {
            return new PetType(type);
        }

        public bool DeletePetType(IPetType petType)
        {
            var deletedPetType = _PetShopDbContext.PetTypes.Remove((PetType)petType).Entity;
            _PetShopDbContext.SaveChanges();
            return deletedPetType != null;
        }

        public List<PetType> ReadPetTypes()
        {
            return _PetShopDbContext.PetTypes.ToList();
        }

        public IPetType GetPetType(int id)
        {
            return ReadPetTypes().FirstOrDefault(x => x.GetId().Equals(id));
        }

        public IPetType GetPetType(IPetType petType)
        {
            return GetPetType(petType.GetId());
        }

        public IPetType UpdatePetType(IPetType petType)
        {
            var updatedPetType = _PetShopDbContext.PetTypes.Update((PetType)petType).Entity;
            _PetShopDbContext.SaveChanges();
            return updatedPetType;
        }


        #endregion
    }
}
