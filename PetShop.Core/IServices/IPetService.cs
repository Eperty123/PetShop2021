using PetShop.Core.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PetShop.Core.IServices
{
    public interface IPetService
    {
        /// <summary>
        /// Add the specified pet to the collection.
        /// </summary>
        /// <param name="pet">The pet to add.</param>
        /// <returns>Returns the added pet.</returns>
        IPet AddPet(IPet pet);

        /// <summary>
        /// Add an array of pets to the collection.
        /// </summary>
        /// <param name="pets">The pets to add.</param>
        void AddPets(params IPet[] pets);

        /// <summary>
        /// Create a new pet instance based on a name, type, color and price.
        /// </summary>
        /// <param name="name">The name of the pet.</param>
        /// <param name="type">The pet´s type.</param>
        /// <param name="color">The pet´s color.</param>
        /// <param name="price">The price of the pet.</param>
        /// <returns>Returns the created pet.</returns>
        IPet CreatePet(string name, string type, string color, double price);

        /// <summary>
        /// Create a new pet instance based on a name, type, color and price.
        /// </summary>
        /// <param name="name">The name of the pet.</param>
        /// <param name="type">The pet´s type.</param>
        /// <param name="color">The pet´s color.</param>
        /// <param name="price">The price of the pet.</param>
        /// <returns>Returns the created pet.</returns>
        IPet CreatePet(string name, IPetType type, Color color, double price);

        /// <summary>
        /// Get a pet by its id.
        /// </summary>
        /// <param name="id">The pet´s id.</param>
        /// <returns>Returns the desired pet.</returns>
        IPet GetPet(int id);

        /// <summary>
        /// Get a pet by its instance.
        /// </summary>
        /// <param name="id">The instance pet to try and get.</param>
        /// <returns>Returns the desired pet.</returns>
        IPet GetPet(IPet pet);

        /// <summary>
        /// Update the desired pet by its instance.
        /// </summary>
        /// <param name="pet">The desired pet to update.</param>
        /// <returns>Returns the updated pet.</returns>
        IPet UpdatePet(IPet pet);

        /// <summary>
        /// Delete a pet by its instance.
        /// </summary>
        /// <param name="pet">The pet to delete.</param>
        /// <returns></returns>
        bool DeletePet(IPet pet);

        /// <summary>
        /// Get all available pets and return it as a list.
        /// </summary>
        /// <returns>Returns the available pets.</returns>
        List<Pet> GetPets();
    }
}
