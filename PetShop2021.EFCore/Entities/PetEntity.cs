using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2021.EFCore.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
