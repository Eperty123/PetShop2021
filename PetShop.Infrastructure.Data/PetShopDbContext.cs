using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Data
{
    public class PetShopDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }
    }
}
