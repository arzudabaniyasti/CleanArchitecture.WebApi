using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

               
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddTransient<IAddressRepositoryAsync, AddressRepositoryAsync>();
            services.AddTransient<ICertificateRepositoryAsync, CertificateRepositoryAsync>();
            services.AddTransient<IWorkHistoryRepositoryAsync, WorkHistoryRepositoryAsync>();
            services.AddTransient<IEducationRepositoryAsync, EducationRepositoryAsync>();

            services.AddTransient<IContactRepositoryAsync, ContactRepositoryAsync>();
            services.AddTransient<IProjectRepositoryAsync, ProjectRepositoryAsync>();
            services.AddTransient<IAnnouncementRepositoryAsync, AnnouncementRepositoryAsync>();
            services.AddTransient<IPersonnelRepositoryAsync, PersonnelRepositoryAsync>();
            services.AddTransient<IInventoryRepositoryAsync, InventoryRepositoryAsync>();
            services.AddTransient<IEventRepositoryAsync, EventRepositoryAsync>();

            #endregion
        }
    }
}
