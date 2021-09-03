namespace PetShop.Core.Models
{
    public class PetType : IPetType
    {
        #region Variables
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructors

        public PetType(int id, string type)
        {
            SetId(id);
            SetName(type);
        }

        public PetType(string type)
        {
            SetName(type);
        }

        #endregion

        #region Methods

        #region Getters

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        #endregion

        #region Setters

        public void SetId(int id)
        {
            if (id >= 0) Id = id;
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
        }

        #endregion

        #endregion
    }
}
