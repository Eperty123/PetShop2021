using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data;

namespace PetShop2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.Start();

            // TODO: Implement PetTypeService.
        }
    }
}
