namespace PetShop.Core.Models
{
    public interface IPetType
    {
        #region Getters

        int GetId();
        string GetName();

        #endregion

        #region Setters

        void SetId(int id);
        void SetName(string name);

        #endregion
    }
}
