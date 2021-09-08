using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
