namespace PetShop.Core.Models
{
    public interface IOwner
    {
        int GetId();
        string GetFirstName();
        string GetLastName();
        string GetAddress();
        int GetPhoneNumber();
        string GetEmail();

        void SetId(int id);
        void SetFirstName(string firstName);
        void SetLastName(string lastName);
        void SetAddress(string address);
        void SetPhoneNumber(int phoneNumber);
        void SetEmail(string email);
    }
}
