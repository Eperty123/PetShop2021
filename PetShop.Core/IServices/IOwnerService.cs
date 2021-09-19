using PetShop.Core.Models;
using System.Collections.Generic;

namespace PetShop.Core.IServices
{
    public interface IOwnerService
    {
        /// <summary>
        /// Add the specified Owner to the collection.
        /// </summary>
        /// <param name="Owner">The Owner to add.</param>
        /// <returns>Returns the added Owner.</returns>
        IOwner AddOwner(IOwner Owner);

        /// <summary>
        /// Add an array of Owners to the collection.
        /// </summary>
        /// <param name="Owners">The Owners to add.</param>
        void AddOwners(params IOwner[] Owners);

        /// <summary>
        /// Create a new Owner instance based on a name, type, color and price.
        /// </summary>
        /// <param name="firstName">The first name of the Owner.</param>
        /// <param name="lastName">The last name of the Owner.</param>
        /// <param name="address">The address of the Owner.</param>
        /// <param name="phoneNumber">The phone number of the Owner.</param>
        /// <param name="email">The email of the Owner.</param>
        /// <returns>Returns the created Owner.</returns>
        IOwner CreateOwner(string firstName, string lastName, string address, int phoneNumber, string email);

        /// <summary>
        /// Get a Owner by its id.
        /// </summary>
        /// <param name="id">The Owner´s id.</param>
        /// <returns>Returns the desired Owner.</returns>
        IOwner GetOwner(int id);

        /// <summary>
        /// Get a Owner by its instance.
        /// </summary>
        /// <param name="id">The instance Owner to try and get.</param>
        /// <returns>Returns the desired Owner.</returns>
        IOwner GetOwner(IOwner Owner);

        /// <summary>
        /// Update the desired Owner by its instance.
        /// </summary>
        /// <param name="Owner">The desired Owner to update.</param>
        /// <returns>Returns the updated Owner.</returns>
        IOwner UpdateOwner(IOwner Owner);

        /// <summary>
        /// Delete a Owner by its instance.
        /// </summary>
        /// <param name="Owner">The Owner to delete.</param>
        /// <returns></returns>
        bool DeleteOwner(IOwner Owner);

        /// <summary>
        /// Get all available Owners and return it as a list.
        /// </summary>
        /// <returns>Returns the available Owners.</returns>
        List<Owner> GetOwners();
    }
}
