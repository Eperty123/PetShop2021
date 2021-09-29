using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data;
using PetShop2021.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop2021.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            // Entity.
            services.AddScoped<IPetRepository, PetEntityRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeEntityRepository>();
            services.AddScoped<IOwnerRepository, OwnerEntityRepository>();

            // In memory database.
            //services.AddDbContext<PetShopDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("PetshopDb");
            //});

            // Sqlite database.
            services.AddDbContext<PetShopDbContext>(options =>
           {
               options.UseSqlServer("Data Source=PetshopDb.db");
           });

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop.RestApi");
                });

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<PetShopDbContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    // Todo: Use Entity class instead of the original class for the DbSet in the PetshopDbContext.
                    // Add dummy data (seed).
                    //var dumdum = context.Pets.Add(new PetShop.Core.Models.Pet()
                    //{
                    //    Id = 1,
                    //    Name = "Aeria",
                    //    PetType = new PetShop.Core.Models.PetType("Cat"),
                    //    BirthDay = DateTime.Now,
                    //    Color = System.Drawing.Color.Red,
                    //    Price = 5
                    //}).Entity;
                }
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
