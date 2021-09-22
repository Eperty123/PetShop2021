﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2021.EFCore.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}