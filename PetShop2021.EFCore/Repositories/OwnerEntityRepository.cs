using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2021.EFCore.Repositories
{
    public class OwnerEntityRepository : IOwnerRepository
    {
        #region Variables

        readonly PetShopDbContext _OwnerShopDbContext;

        #endregion

        #region Constructors

        public OwnerEntityRepository(PetShopDbContext OwnerShopDbContext)
        {
            _OwnerShopDbContext = OwnerShopDbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add test data.
        /// </summary>
        void InitData()
        {

            #region Owner test data

            var testOwners = new List<IOwner>()
            {
                CreateOwner("Emma", "Watson", "This Street 123", 12345678, "emmawatson@test.com"),
            };

            AddOwners(testOwners);

            #endregion
        }

        /// <summary>
        /// Add an array of Owners to the Owner repository.
        /// </summary>
        /// <param name="Owners">The Owners to add.</param>
        public void AddOwners(params IOwner[] Owners)
        {
            for (int i = 0; i < Owners.Length; i++)
                AddOwner(Owners[i]);
        }

        /// <summary>
        /// Add an array of Owners to the Owner repository.
        /// </summary>
        /// <param name="Owners">The Owners to add.</param>
        public void AddOwners(IEnumerable<IOwner> Owners)
        {
            var _Owners = new List<IOwner>(Owners);
            for (int i = 0; i < _Owners.Count; i++)
                AddOwner(_Owners[i]);
        }

        public IOwner AddOwner(IOwner Owner)
        {
            var addedOwner = _OwnerShopDbContext.Owners.Add((Owner)Owner).Entity;
            _OwnerShopDbContext.SaveChanges();
            return addedOwner;
        }

        public IOwner CreateOwner(string firstName, string lastName, string address, int phoneNumber, string email)
        {
            return new Owner()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
            };
        }

        public bool DeleteOwner(IOwner Owner)
        {
            var deletedOwner = _OwnerShopDbContext.Owners.Remove((Owner)Owner).Entity;
            _OwnerShopDbContext.SaveChanges();
            return deletedOwner != null;
        }

        public List<Owner> ReadOwners()
        {
            return _OwnerShopDbContext.Owners.ToList();
        }

        public IOwner GetOwner(int id)
        {
            return ReadOwners().FirstOrDefault(x => x.GetId().Equals(id));
        }

        public IOwner GetOwner(IOwner Owner)
        {
            return GetOwner(Owner.GetId());
        }

        public IOwner UpdateOwner(IOwner Owner)
        {
            var updatedOwner = _OwnerShopDbContext.Owners.Update((Owner)Owner).Entity;
            _OwnerShopDbContext.SaveChanges();
            return updatedOwner;
        }

        #endregion
    }
}
