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

        readonly FakeDB FakeDB;

        #endregion

        #region Constructors
        public PetTypeRepository(FakeDB fakeDB)
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

        public void AddPetTypes(params IPetType[] pets)
        {
            for (int i = 0; i < pets.Length; i++)
                AddPetType(pets[i]);
        }

        public void AddPetTypes(IEnumerable<IPetType> pets)
        {
            var _pets = new List<IPetType>(pets);
            for (int i = 0; i < _pets.Count; i++)
                AddPetType(_pets[i]);
        }

        public IPetType AddPetType(IPetType petType)
        {
            FakeDB.AddPetType(petType);
            return petType;
        }

        public IPetType CreatePetType(string type)
        {
            return new PetType(type);
        }

        public bool DeletePetType(IPetType petType)
        {
            return FakeDB.DeletePetType(petType);
        }

        public List<PetType> ReadPetTypes()
        {
            return FakeDB.GetPetTypes().OfType<PetType>().ToList();
        }

        public IPetType GetPetType(int id)
        {
            return FakeDB.GetPetType(id);
        }

        public IPetType GetPetType(IPetType petType)
        {
            throw new NotImplementedException();
        }

        public IPetType UpdatePetType(IPetType petType)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
