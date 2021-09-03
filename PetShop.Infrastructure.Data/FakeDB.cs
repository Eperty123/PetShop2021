﻿using PetShop.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        #region Variables
        static List<IPet> Pets = new List<IPet>();
        static List<IPetType> PetTypes = new List<IPetType>();

        static int Id;
        #endregion

        #region Methods

        #region Pet CRUD
        public IPet AddPet(IPet pet)
        {
            Id = Pets.Count + 1;
            pet.SetId(Id);
            Pets.Add(pet);
            return pet;
        }

        public IPet GetPet(int id)
        {
            return GetPets().ToList().Find(x => x.GetId().Equals(id));
        }

        public IPet GetPet(IPet pet)
        {
            return GetPets().ToList().Find(x => x.GetId().Equals(pet.GetId()));
        }

        public IPet UpdatePet(IPet pet)
        {
            var existingPet = GetPet(pet);

            if (existingPet != null)
            {
                existingPet.SetName(pet.GetName());
                existingPet.SetBirthDay(pet.GetBirthDay());
                existingPet.SetColor(pet.GetColor());
                existingPet.SetPetType(pet.GetPetType());
                existingPet.SetPrice(pet.GetPrice());
                existingPet.SetSellDate(pet.GetSellDate());
                return existingPet;
            }
            return null;
        }

        public bool DeletePet(IPet pet)
        {
            return Pets.Remove(pet);
        }

        public IEnumerable<IPet> GetPets()
        {
            return Pets;
        }

        #endregion

        #region Pet Type CRUD

        public IPetType AddPetType(IPetType petType)
        {
            petType.SetId(PetTypes.Count + 1);
            PetTypes.Add(petType);
            return petType;
        }

        public IPetType GetPetType(IPetType petType)
        {
            return GetPetTypes().ToList().Find(x => x.GetId().Equals(petType.GetId()));
        }

        public IPetType UpdatePetType(IPetType petType)
        {
            var existingPetType = GetPetType(petType);
            existingPetType.SetName(petType.GetName());

            return existingPetType;
        }

        public bool DeletePetType(IPetType petType)
        {
            return PetTypes.Remove(petType);
        }

        public IEnumerable<IPetType> GetPetTypes()
        {
            return PetTypes;
        }

        #endregion

        #endregion
    }
}