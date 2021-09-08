using PetShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.IServices
{
    public interface IOwnerService
    {
        /// <summary>
        /// Add a new pet type to the repository by an pet type instance.
        /// </summary>
        /// <param name="Owner">The pet type instance to add.</param>
        /// <returns>Returns the added pet.</returns>
        IOwner AddOwner(IOwner Owner);

        /// <summary>
        /// Create a new pet type instance with the desired type.
        /// </summary>
        /// <param name="type">The desired pet type.</param>
        /// <returns>Returns the created pet type.</returns>
        IOwner CreateOwner(string name);

        /// <summary>
        /// Get a pet type by its id.
        /// </summary>
        /// <param name="id">The deisred pet type id.</param>
        /// <returns>Returns the desired pet type.</returns>
        IOwner GetOwner(int id);

        /// <summary>
        /// Get a pet type by its type name.
        /// </summary>
        /// <param name="typeName">The deisred pet type name.</param>
        /// <returns>Returns the desired pet type.</returns>
        IOwner GetOwner(string typeName);

        /// <summary>
        /// Get a pet type by its instance.
        /// </summary>
        /// <param name="Owner">The deisred pet type instance.</param>
        /// <returns>Returns the desired pet type.</returns>
        IOwner GetOwner(IOwner Owner);

        /// <summary>
        /// Update the desired pet type by its instance.
        /// </summary>
        /// <param name="Owner">The pet type to update.</param>
        /// <returns>Returns the updated pet type.</returns>
        IOwner UpdateOwner(IOwner Owner);

        /// <summary>
        /// Delete the pet type specified by an instance.
        /// </summary>
        /// <param name="Owner">The pet type instance to delete.</param>
        /// <returns></returns>
        bool DeleteOwner(IOwner Owner);

        /// <summary>
        /// Get all available pet types and return them as a list.
        /// </summary>
        /// <returns>Returns a list of available pet types.</returns>
        List<Owner> GetOwners();
    }
}
