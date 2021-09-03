using PetShop.Core.IServices;
using PetShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PetShop2021
{
    public class Printer : IPrinter
    {
        #region Variables

        readonly IPetService _PetService;
        readonly IPetTypeService _PetTypeService;
        List<string> _MenuOptions;

        #endregion

        #region Constructors

        public Printer(IPetService petService)
        {
            _PetService = petService;
        }

        public Printer(IPetService petService, IPetTypeService petTypeService)
        {
            _PetService = petService;
            _PetTypeService = petTypeService;
        }

        #endregion

        #region Methods

        #region Helper Methods

        /// <summary>
        /// Ask the user a question and wait for its input.
        /// </summary>
        /// <param name="question">The question to ask.</param>
        /// <returns></returns>
        string AskQuestion(string question)
        {
            Tell(question);
            return GetUserInput();
        }

        /// <summary>
        /// Print the desired text.
        /// </summary>
        /// <param name="text">The text to print.</param>
        void Tell(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Get the user's input.
        /// </summary>
        /// <returns></returns>
        string GetUserInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Get the selected index of the specified menu options.
        /// </summary>
        /// <param name="menuOptions">The menu options to show.</param>
        /// <returns></returns>
        int GetSelectedOptionIndex(IEnumerable<string> menuOptions)
        {
            var _menuOptions = new List<string>(menuOptions);
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Tell($"{(i + 1)}: {_menuOptions[i]}");
            }

            int selection;
            while (!int.TryParse(GetUserInput(), out selection) || selection < 1 || selection > _menuOptions.Count)
            {
                Tell($"Invalid option. Please select a number between 1 - {_menuOptions.Count}.");
            }

            Tell($"You selected: {_menuOptions[selection - 1]}.");
            return selection;
        }

        /// <summary>
        /// Get a number (double) from the specified string.
        /// </summary>
        /// <param name="number">The string to parse as a number.</param>
        /// <returns></returns>
        double GetNumberFromString(string number)
        {
            double result = 0;
            double.TryParse(number, out result);
            return result;
        }

        #endregion

        #region UI Methods

        #region Pet

        /// <summary>
        /// Get an <see cref="IPet"/> by an id.
        /// </summary>
        /// <param name="id">The id of the pet.</param>
        /// <returns></returns>
        IPet GetPetById(int id)
        {
            return _PetService.GetPet(id);
        }

        /// <summary>
        /// Ask and return the desired pet by id.
        /// </summary>
        /// <returns></returns>
        IPet AskAndReturnPetById()
        {
            var _id = (int)GetNumberFromString(AskQuestion("What's the pet's id?"));
            return GetPetById(_id);
        }

        /// <summary>
        /// List the specified pet's info.
        /// </summary>
        /// <param name="pet">The pet to retrieve info for.</param>
        void PrintInfoForPet(IPet pet)
        {
            if (pet != null) Tell($"{pet.GetId()}: Name: {pet.GetName()}, type: {pet.GetPetType().GetName()}, color: {pet.GetColor().Name}, price: {pet.GetPrice()}");
        }

        /// <summary>
        /// List all the available pets.
        /// </summary>
        void ListPets()
        {
            var pets = _PetService.GetPets().ToList();
            if (pets != null && pets.Count > 0)
            {
                Tell("");
                Tell($"Showing {pets.Count} {(pets.Count > 1 ? "pets" : "pet")}:");
                for (int i = 0; i < pets.Count; i++)
                {
                    var pet = pets[i];
                    PrintInfoForPet(pet);
                }
            }
            else Tell("There are no pets in the store! Gotta catch 'em all, sir!");
        }

        void ListPetsAndSortByPrice()
        {
            var pets = _PetService.GetPets().OrderBy(x => x.GetPrice()).ToList();
            if (pets != null && pets.Count > 0)
            {
                Tell("");
                Tell($"Showing {pets.Count} {(pets.Count > 1 ? "pets" : "pet")} sorted by price (low to high):");
                for (int i = 0; i < pets.Count; i++)
                {
                    var pet = pets[i];
                    PrintInfoForPet(pet);
                }
            }
            else Tell("There are no pets in the store! Gotta catch 'em all, sir!");
        }

        void ListFiveCheapestPets()
        {
            var pets = _PetService.GetPets().OrderBy(x => x.GetPrice()).Take(5).ToList();
            if (pets != null && pets.Count > 0)
            {
                Tell("");
                Tell($"Showing {pets.Count} cheapest {(pets.Count > 1 ? "pets" : "pet")} sorted by price (low to high):");
                for (int i = 0; i < pets.Count; i++)
                {
                    var pet = pets[i];
                    PrintInfoForPet(pet);
                }
            }
            else Tell("There are no pets in the store! Gotta catch 'em all, sir!");
        }

        #endregion

        #region Pet Type

        /// <summary>
        /// Get an <see cref="IPetType"/> by an id.
        /// </summary>
        /// <param name="id">The id of the pet type.</param>
        /// <returns></returns>
        IPetType GetPetTypeById(int id)
        {
            return _PetTypeService.GetPetType(id);
        }

        /// <summary>
        /// Get an <see cref="IPetType"/> by its type name (case insensitive).
        /// </summary>
        /// <param name="id">The type name of the pet type.</param>
        /// <returns></returns>
        IPetType GetPetTypeByTypeName(string typeName)
        {
            return _PetTypeService.GetPetType(typeName);
        }

        /// <summary>
        /// Ask and return the desired pet by id.
        /// </summary>
        /// <returns></returns>
        IPetType AskAndReturnPetTypeByTypeName()
        {
            var name = AskQuestion("What type should it be?");
            return GetPetTypeByTypeName(name);
        }

        #endregion

        #region Menu

        /// <summary>
        /// Show the menu.
        /// </summary>
        void ShowMenu()
        {
            // All the available menu options.
            _MenuOptions = new List<string>()
            {
                "Add pet",
                "Delete pet",
                "Edit pet",
                "Get pet info",
                "List pets",
                "Sort pets by price",
                "List five cheapest pets",
                "Exit",
            };

            // Hardcoded for now...
            Tell($"Welcome to De Leon's Pet Shop!");
            Tell("You have the following options:");

            HandleSelection();
        }

        /// <summary>
        /// Handle user selection.
        /// </summary>
        void HandleSelection()
        {
            var selection = GetSelectedOptionIndex(_MenuOptions);

            switch (selection)
            {
                case 1:
                    var name = AskQuestion("Give your new pet a name.");
                    var color = AskQuestion("Give it a color.");
                    var type = AskQuestion("Give it a type (cat, dog or goat). More on the way!");

                    var desiredType = GetPetTypeByTypeName(type);
                    if (desiredType != null)
                    {
                        var price = AskQuestion("Give it a price.");

                        var newPet = _PetService.CreatePet(name, desiredType, Color.FromName(color), GetNumberFromString(price));
                        if (_PetService.AddPet(newPet) != null) Tell($"{name} has been added.");
                        else Tell($"{name} couldn't be added.");
                    }
                    else Tell("As clearly stated we don´t have that animal type yet! Covid did that to us, so please be patient.");
                    break;

                case 2:
                    var desiredPet = AskAndReturnPetById();

                    if (desiredPet != null && _PetService.DeletePet(desiredPet)) Tell($"{desiredPet.GetName()} was re-homed and no longer part of the shop.");
                    else Tell("The desired pet was not found. Maybe it ran away?");
                    break;

                case 3:
                    desiredPet = AskAndReturnPetById();

                    if (desiredPet != null)
                    {
                        var oldName = desiredPet.GetName();
                        Tell($"So you want to update: {oldName}? Okay then!");

                        name = AskQuestion("Give your new pet a new name.");
                        color = AskQuestion("Give it a new color.");
                        type = AskQuestion("Give it a new type (cat, dog or goat). More on the way!");

                        desiredType = GetPetTypeByTypeName(type);
                        if (desiredType != null)
                        {
                            var price = AskQuestion("Give it a new price.");

                            var newPet = new Pet()
                            {
                                Id = desiredPet.GetId(),
                                Name = name,
                                Color = Color.FromName(color),
                                PetType = desiredType,
                                Price = GetNumberFromString(price),
                            };

                            if (_PetService.UpdatePet(newPet) != null) Tell($"{oldName} {(!oldName.Equals(name) ? "(now: {name}) " : "")}has been updated.");
                            else Tell($"{name} couldn't be updated.");
                        }
                        else Tell("As clearly stated we don´t have that animal type yet! Covid did that to us, so please be patient.");
                    }
                    else Tell("The desired pet was not found. Maybe it ran away?");

                    break;

                case 4:
                    desiredPet = AskAndReturnPetById();

                    if (desiredPet != null) PrintInfoForPet(desiredPet);
                    else Tell("The desired pet was not found. Maybe it ran away?");
                    break;

                case 5:
                    ListPets();
                    break;

                case 6:
                    ListPetsAndSortByPrice();
                    break;

                case 7:
                    ListFiveCheapestPets();
                    break;

            }

            // Only re-show the menu if the user hasn't chosen to quit.
            if (selection != _MenuOptions.Count)
            {
                Tell("");
                ShowMenu();
            }
        }

        public void Start()
        {
            ShowMenu();
        }

        #endregion

        #endregion


        #endregion
    }
}
