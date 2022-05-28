using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity.Models;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);


                    var categoryRepository = services.GetRequiredService<ICategoryRepositoryAsync>();
                    var productRepository = services.GetRequiredService<IProductRepositoryAsync>();
                    var addressRepository = services.GetRequiredService<IAddressRepositoryAsync>();
                    var certificateRepository = services.GetRequiredService<ICertificateRepositoryAsync>();
                    var workHistoryRepository = services.GetRequiredService<IWorkHistoryRepositoryAsync>();
                    var educationRepository = services.GetRequiredService<IEducationRepositoryAsync>();
                    var filmRepository = services.GetRequiredService<IFilmmRepositoryAsync>();
                    var projectRepository = services.GetRequiredService<IProjectRepositoryAsync>();

                    var searchRepository = services.GetRequiredService<ISearchRepositoryAsync>();
                    var watchedListRepository = services.GetRequiredService<IWatchedListRepositoryAsync>();
                    var watchListproductRepository = services.GetRequiredService<IWatchListRepositoryAsync>();
                    var diaryRepository = services.GetRequiredService<IDiaryRepositoryAsync>();

                    var contactRepository = services.GetRequiredService<IContactRepositoryAsync>();

                    var announcementRepository = services.GetRequiredService<IAnnouncementRepositoryAsync>();
                    var personnelRepository = services.GetRequiredService<IPersonnelRepositoryAsync>();
                    var inventoryRepository = services.GetRequiredService<IInventoryRepositoryAsync>();
                   // var eventRepository = services.GetRequiredService<IEventRepositoryAsync>();
                    //var logger = services.GetRequiredService<Microsoft.Extensions.Logging.ILogger>();
                    await Infrastructure.Persistence.Seeds.DefaultCategories.SeedAsync(categoryRepository);
                    await Infrastructure.Persistence.Seeds.DefaultAddresses.SeedAsync(addressRepository);
                    await Infrastructure.Persistence.Seeds.DefaultCertificates.SeedAsync(certificateRepository);
                    await Infrastructure.Persistence.Seeds.DefaultWorkHistories.SeedAsync(workHistoryRepository);
                    await Infrastructure.Persistence.Seeds.DefaultEducations.SeedAsync(educationRepository);
                    await Infrastructure.Persistence.Seeds.DefaultProjects.SeedAsync(projectRepository);
                    await Infrastructure.Persistence.Seeds.DefaultContacts.SeedAsync(contactRepository);
                    await Infrastructure.Persistence.Seeds.DefaultFilms.SeedAsync(filmRepository);


                    await Infrastructure.Persistence.Seeds.DefaultAnnouncements.SeedAsync(announcementRepository);
                    await Infrastructure.Persistence.Seeds.DefaultPersonnels.SeedAsync(personnelRepository);
                    await Infrastructure.Persistence.Seeds.DefaultProducts.SeedAsync(productRepository);

                    await Infrastructure.Persistence.Seeds.DefaultSearches.SeedAsync(searchRepository);
                    await Infrastructure.Persistence.Seeds.DefaultWatchedLists.SeedAsync(watchedListRepository);
                    await Infrastructure.Persistence.Seeds.DefaultWatchLists.SeedAsync(watchListproductRepository);
                    await Infrastructure.Persistence.Seeds.DefaultDiaries.SeedAsync(diaryRepository);

                    await Infrastructure.Persistence.Seeds.DefaultInventories.SeedAsync(inventoryRepository, productRepository);
                    //await Infrastructure.Persistence.Seeds.DefaultEvents.SeedAsync(eventRepository, personnelRepository,addressRepository);

                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                    host.Run();
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
