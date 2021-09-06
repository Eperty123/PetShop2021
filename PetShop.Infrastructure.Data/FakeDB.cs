using PetShop.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        #region Variables
        static List<Pet> Pets = new List<Pet>();
        static List<PetType> PetTypes = new List<PetType>();

        static int Id;
        static int PetTypeId;
        #endregion

        #region Methods

        #region Pet CRUD

        /// <summary>
        /// Add the specified pet to the pet repository.
        /// </summary>
        /// <param name="pet">The pet to add.</param>
        /// <returns>Returns the added pet.</returns>
        public IPet AddPet(IPet pet)
        {
            Id++;
            pet.SetId(Id);
            Pets.Add((Pet)pet);
            return pet;
        }


        /// <summary>
        /// Get a pet by its id.
        /// </summary>
        /// <param name="id">The pet´s id.</param>
        /// <returns>Returns the desired pet.</returns>
        public IPet GetPet(int id)
        {
            return GetPets().Find(x => x.GetId().Equals(id));
        }

        /// <summary>
        /// Get a pet by its instance.
        /// </summary>
        /// <param name="id">The instance pet to try and get.</param>
        /// <returns>Returns the desired pet.</returns>
        public IPet GetPet(IPet pet)
        {
            return GetPets().Find(x => x.GetId().Equals(pet.GetId()));
        }

        /// <summary>
        /// Update the desired pet by its instance.
        /// </summary>
        /// <param name="pet">The desired pet to update.</param>
        /// <returns>Returns the updated pet.</returns>
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

        /// <summary>
        /// Delete a pet by its instance.
        /// </summary>
        /// <param name="pet">The pet to delete.</param>
        /// <returns></returns>
        public bool DeletePet(IPet pet)
        {
            return Pets.Remove((Pet)pet);
        }

        /// <summary>
        /// Get all available pets and return it as a list.
        /// </summary>
        /// <returns>Returns the available pets.</returns>
        public List<Pet> GetPets()
        {
            return Pets;
        }

        #endregion

        #region Pet Type CRUD

        /// <summary>
        /// Add a new pet type to the repository by an pet type instance.
        /// </summary>
        /// <param name="petType">The pet type instance to add.</param>
        /// <returns>Returns the added pet.</returns>
        public IPetType AddPetType(IPetType petType)
        {
            PetTypeId++;
            petType.SetId(PetTypeId);
            PetTypes.Add((PetType)petType);
            return petType;
        }

        /// <summary>
        /// Get a pet type by its type name.
        /// </summary>
        /// <param name="typeName">The deisred pet type name.</param>
        /// <returns>Returns the desired pet type.</returns>
        public IPetType GetPetType(IPetType petType)
        {
            return GetPetType(petType.GetId());
        }

        /// <summary>
        /// Get a pet type by its id.
        /// </summary>
        /// <param name="id">The deisred pet type id.</param>
        /// <returns>Returns the desired pet type.</returns>
        public IPetType GetPetType(int id)
        {
            return GetPetTypes().ToList().Find(x => x.GetId().Equals(id));
        }

        /// <summary>
        /// Update the desired pet type by its instance.
        /// </summary>
        /// <param name="petType">The pet type to update.</param>
        /// <returns>Returns the updated pet type.</returns>
        public IPetType UpdatePetType(IPetType petType)
        {
            var existingPetType = GetPetType(petType);
            existingPetType.SetName(petType.GetName());

            return existingPetType;
        }

        /// <summary>
        /// Delete the pet type specified by an instance.
        /// </summary>
        /// <param name="petType">The pet type instance to delete.</param>
        /// <returns></returns>
        public bool DeletePetType(IPetType petType)
        {
            return PetTypes.Remove((PetType)petType);
        }

        /// <summary>
        /// Get all available pet types and return them as a list.
        /// </summary>
        /// <returns>Returns a list of available pet types.</returns>
        public IEnumerable<IPetType> GetPetTypes()
        {
            return PetTypes;
        }

        #endregion

        #endregion
    }
}
