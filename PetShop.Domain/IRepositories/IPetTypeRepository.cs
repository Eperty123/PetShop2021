using PetShop.Core.Models;
using System.Collections.Generic;

namespace PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        /// <summary>
        /// Add a new pet type to the repository by an pet type instance.
        /// </summary>
        /// <param name="petType">The pet type instance to add.</param>
        /// <returns>Returns the added pet.</returns>
        IPetType AddPetType(IPetType petType);

        /// <summary>
        /// Create a new pet type instance with the desired type.
        /// </summary>
        /// <param name="type">The desired pet type.</param>
        /// <returns>Returns the created pet type.</returns>
        IPetType CreatePetType(string type);

        /// <summary>
        /// Get a pet type by its id.
        /// </summary>
        /// <param name="id">The deisred pet type id.</param>
        /// <returns>Returns the desired pet type.</returns>
        IPetType GetPetType(int id);

        /// <summary>
        /// Get a pet type by its instance.
        /// </summary>
        /// <param name="petType">The deisred pet type instance.</param>
        /// <returns>Returns the desired pet type.</returns>
        IPetType GetPetType(IPetType petType);

        /// <summary>
        /// Update the desired pet type by its instance.
        /// </summary>
        /// <param name="petType">The pet type to update.</param>
        /// <returns>Returns the updated pet type.</returns>
        IPetType UpdatePetType(IPetType petType);

        /// <summary>
        /// Delete the pet type specified by an instance.
        /// </summary>
        /// <param name="petType">The pet type instance to delete.</param>
        /// <returns></returns>
        bool DeletePetType(IPetType petType);

        /// <summary>
        /// Get all available pet types and return them as a list.
        /// </summary>
        /// <returns>Returns a list of available pet types.</returns>
        List<PetType> ReadPetTypes();
    }
}
