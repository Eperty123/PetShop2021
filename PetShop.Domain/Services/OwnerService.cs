using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {

        #region Variables

        // TODO: Use IOwnerRepository for the methods.
        readonly IOwnerRepository _OwnerRepository;

        #endregion

        #region Constructors

        public OwnerService() { }

        public OwnerService(IOwnerRepository OwnerRepository)
        {
            _OwnerRepository = OwnerRepository;
        }

        #endregion

        #region Methods

        public IOwner AddOwner(IOwner Owner)
        {
            return _OwnerRepository.AddOwner(Owner);
        }

        public void AddOwners(params IOwner[] Owners)
        {
            for (int i = 0; i < Owners.Length; i++)
                AddOwner(Owners[i]);
        }

        public IOwner CreateOwner(string firstName, string lastName, string address, int phoneNumber, string email)
        {
            return _OwnerRepository.CreateOwner(firstName, lastName, address, phoneNumber, email);
        }

        public bool DeleteOwner(IOwner Owner)
        {
            return _OwnerRepository.DeleteOwner(Owner);
        }

        public List<Owner> GetOwners()
        {
            return _OwnerRepository.ReadOwners();
        }

        public IOwner GetOwner(int id)
        {
            return _OwnerRepository.GetOwner(id);
        }

        public IOwner GetOwner(IOwner Owner)
        {
            return _OwnerRepository.GetOwner(Owner);
        }

        public IOwner UpdateOwner(IOwner Owner)
        {
            return _OwnerRepository.UpdateOwner(Owner);
        }

        #endregion
    }
}
