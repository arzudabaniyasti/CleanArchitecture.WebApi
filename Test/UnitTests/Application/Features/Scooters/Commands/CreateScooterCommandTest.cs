//using System;
//using System.Threading.Tasks;
//using EScooterON.WebApi.Application;
//using EScooterON.WebApi.Application.Features.Reports.Queries;
//using EScooterON.WebApi.Application.Features.Scooters.Commands.CreateScooter;
//using EScooterON.WebApi.Application.Interfaces;
//using EScooterON.WebApi.Infrastructure.Persistence;
//using EScooterON.WebApi.Infrastructure.Persistence.Contexts;
//using EScooterON.WebApi.Infrastructure.Shared;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;

//namespace UnitTests.Application.Features.Scooter.Commands
//{
//    public class CreateScooterCommandTest
//    {
//        private IMediator _mediator;
      
//        public CreateScooterCommandTest()
//        {
//            var services = new ServiceCollection();
           
//            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("Scooter"));
//            services.AddPersistenceInfrastructure();
//            services.AddApplicationLayer();
//            services.AddSharedInfrastructure();

           
//            var serviceProvider = services.BuildServiceProvider();
//            _mediator = serviceProvider.GetService<IMediator>();
//        }


//        //[Fact]
//        //public async Task Test1Async()
//        //{
//        //    CreateScooterCommand command = new CreateScooterCommand
//        //    {
//        //        ScooterBarcode = "Barcode",
//        //        ScooterDescription = "Description",
//        //        ScooterImei = "IMEI",
//        //        ScooterGsmNumber = "554627263",
//        //      //  ScooterName = "ScooterName",
//        //      //   ScooterRate = 65
//        //    };

//        //    var result = await _mediator.Send(command);
//        //    var x = result;

//        //}

//        [Fact]
//        public async Task GetScooterNotUsedReportTest()
//        {
//            GetScootersNotUsedReportQuery command = new GetScootersNotUsedReportQuery()
//            {
//                StartDateTime = DateTime.UtcNow.AddDays(-1),
//                EndDateTime = DateTime.UtcNow
//            };



//            var result = await _mediator.Send(command);
//            Assert.True(result.Succeeded);
//            Console.WriteLine(result.Message);
            

//        }


//    }

//    internal interface IMediator
//    {
//    }
//}
