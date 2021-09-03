using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        #region Variables
        readonly IPetTypeRepository _PetTypeRepository;
        #endregion

        #region Constructors

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _PetTypeRepository = petTypeRepository;
        }

        #endregion

        #region Methods

        public IPetType AddPetType(IPetType petType)
        {
            return _PetTypeRepository.AddPetType(petType);
        }

        public IPetType CreatePetType(string name)
        {
            return _PetTypeRepository.CreatePetType(name);
        }

        public bool DeletePetType(IPetType petType)
        {
            return _PetTypeRepository.DeletePetType(petType);
        }

        public List<IPetType> GetPetTypes()
        {
            return _PetTypeRepository.GetPetTypes().ToList();
        }
        public IPetType GetPetType(int id)
        {
            return _PetTypeRepository.GetPetType(id);
        }

        public IPetType GetPetType(IPetType petType)
        {
            return _PetTypeRepository.GetPetType(petType);
        }

        public IPetType UpdatePetType(IPetType petType)
        {
            return _PetTypeRepository.UpdatePetType(petType);
        }

        #endregion
    }
}
