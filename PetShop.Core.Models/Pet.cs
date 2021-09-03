using System;
using System.Drawing;

namespace PetShop.Core.Models
{
    public class Pet : IPet
    {
        #region Variables
        public int Id { get; set; }
        public string Name { get; set; }
        public IPetType PetType { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime SellDate { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }
        #endregion

        #region Constructors

        public Pet() { }

        public Pet(int id, string name, IPetType petType, DateTime birthDay, DateTime sellDate, Color color, double price)
        {
            Id = id;
            Name = name;
            PetType = petType;
            BirthDay = birthDay;
            SellDate = sellDate;
            Color = color;
            Price = price;
        }

        #endregion

        #region Methods

        #region Getters
        public DateTime GetBirthDay()
        {
            return BirthDay;
        }

        public Color GetColor()
        {
            return Color;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public IPetType GetPetType()
        {
            return PetType;
        }

        public double GetPrice()
        {
            return Price;
        }

        public DateTime GetSellDate()
        {
            return SellDate;
        }

        #endregion

        #region Setters

        public void SetBirthDay(DateTime birthDay)
        {
            BirthDay = birthDay;
        }

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
        }

        public void SetPetType(IPetType petType)
        {
            PetType = petType;
        }

        public void SetPrice(double price)
        {
            if (price >= 0) Price = price;
        }

        public void SetSellDate(DateTime sellDate)
        {
            SellDate = sellDate;
        }

        #endregion

        #endregion
    }
}
