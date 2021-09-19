using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Models
{
    public class Owner : IOwner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public string GetAddress()
        {
            return Address;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public int GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetPhoneNumber(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
