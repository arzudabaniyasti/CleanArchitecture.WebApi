using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using WebApi;
using Infrastructure.Identity.Models;
using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace IntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(async services =>
            {

                // Add a database context (ApplicationDbContext) using an in-memory
                // database for testing.

                // Build the service provider.
                var sp = services.BuildServiceProvider();
                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var services2 = scope.ServiceProvider;
                    try
                    {
                        var userManager = services2.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = services2.GetRequiredService<RoleManager<IdentityRole>>();
                        var accountService = services2.GetRequiredService<IAccountService>();


                        await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                        await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                        await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);

                        var categoryRepository = services2.GetRequiredService<ICategoryRepositoryAsync>();
                        var productRepository = services2.GetRequiredService<IProductRepositoryAsync>();
                        var addressRepository = services2.GetRequiredService<IAddressRepositoryAsync>();
                        var certificateRepository = services2.GetRequiredService<ICertificateRepositoryAsync>();
                        var projectRepository = services2.GetRequiredService<IProjectRepositoryAsync>();
                        var workHistoryRepository = services2.GetRequiredService<IWorkHistoryRepositoryAsync>();
                        var announcementRepository = services2.GetRequiredService<IAnnouncementRepositoryAsync>();
                        var educationRepository = services2.GetRequiredService<IEducationRepositoryAsync>();
                        var contactRepository = services2.GetRequiredService<IContactRepositoryAsync>();
                        var filmRepository = services2.GetRequiredService<IFilmmRepositoryAsync>();


                        var personnelRepository = services2.GetRequiredService<IPersonnelRepositoryAsync>();
                        var inventoryRepository = services2.GetRequiredService<IInventoryRepositoryAsync>();
                       // var eventRepository = services2.GetRequiredService<IEventRepositoryAsync>();

                        await Infrastructure.Persistence.Seeds.DefaultCategories.SeedAsync(categoryRepository);
                        await Infrastructure.Persistence.Seeds.DefaultAddresses.SeedAsync(addressRepository);
                        await Infrastructure.Persistence.Seeds.DefaultCertificates.SeedAsync(certificateRepository);
                        await Infrastructure.Persistence.Seeds.DefaultWorkHistories.SeedAsync(workHistoryRepository);
                        await Infrastructure.Persistence.Seeds.DefaultEducations.SeedAsync(educationRepository);
                        await Infrastructure.Persistence.Seeds.DefaultProjects.SeedAsync(projectRepository);
                        await Infrastructure.Persistence.Seeds.DefaultContacts.SeedAsync(contactRepository);

                        //await EScooterON.WebApi.Infrastructure.Persistence.Seeds.DefaultTrip.SeedAsync(tripRepository);
                        //await EScooterON.WebApi.Infrastructure.Persistence.Seeds.DefaultFinancialAccounts.SeedAsync   (financialAccountRepository,tripRepository, productRepository,groupRepository,userManager, roleManager, promotionRepository);
                        await Infrastructure.Persistence.Seeds.DefaultAnnouncements.SeedAsync(announcementRepository);
                        await Infrastructure.Persistence.Seeds.DefaultPersonnels.SeedAsync(personnelRepository);
                        await Infrastructure.Persistence.Seeds.DefaultProducts.SeedAsync(productRepository);
                        await Infrastructure.Persistence.Seeds.DefaultFilms.SeedAsync(filmRepository);
                        await Infrastructure.Persistence.Seeds.DefaultInventories.SeedAsync(inventoryRepository, productRepository);
                      //  await Infrastructure.Persistence.Seeds.DefaultEvents.SeedAsync(eventRepository, personnelRepository,addressRepository);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }
    }
}