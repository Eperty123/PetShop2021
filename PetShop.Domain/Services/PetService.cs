using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {

        #region Variables

        // TODO: Use IPetRepository for the methods.
        readonly IPetRepository _PetRepository;

        #endregion

        #region Initialization

        public PetService() { }

        public PetService(IPetRepository petRepository)
        {
            _PetRepository = petRepository;
        }
        #endregion

        #region Methods

        public IPet AddPet(IPet pet)
        {
            return _PetRepository.AddPet(pet);
        }

        public void AddPets(params IPet[] pets)
        {
            for (int i = 0; i < pets.Length; i++)
                AddPet(pets[i]);
        }

        public IPet CreatePet(string name, string type, string color, double price)
        {
            return _PetRepository.CreatePet(name, type, color, price);
        }

        public IPet CreatePet(string name, IPetType type, Color color, double price)
        {
            return _PetRepository.CreatePet(name, type, color, price);
        }

        public bool DeletePet(IPet pet)
        {
            return _PetRepository.DeletePet(pet);
        }

        public List<IPet> GetPets()
        {
            return _PetRepository.GetPets().ToList();
        }

        public IPet GetPet(int id)
        {
            return _PetRepository.GetPet(id);
        }

        public IPet GetPet(IPet pet)
        {
            return _PetRepository.GetPet(pet);
        }

        public IPet UpdatePet(IPet pet)
        {
            return _PetRepository.UpdatePet(pet);
        }

        #endregion
    }
}
