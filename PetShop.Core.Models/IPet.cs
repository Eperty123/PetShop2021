using System;
using System.Drawing;

namespace PetShop.Core.Models
{
    public interface IPet
    {
        #region Getters
        int GetId();
        string GetName();
        PetType GetPetType();
        DateTime GetBirthDay();
        DateTime GetSellDate();
        Color GetColor();
        double GetPrice();
        #endregion

        #region Setters
        void SetId(int id);
        void SetName(string name);
        void SetPetType(IPetType petType);
        void SetBirthDay(DateTime birthDay);
        void SetSellDate(DateTime sellDate);
        void SetColor(Color color);
        void SetPrice(double price);
        #endregion
    }
}
