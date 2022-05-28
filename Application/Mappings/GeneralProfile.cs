using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Queries.GetAllAddresses;
using Application.Features.Addresses.Commands.UpdateAddress;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.Certificates.Queries.GetAllCertificates;
using Application.Features.Certificates.Commands.CreateCertificate;
using Application.Features.Certificates.Commands.UpdateCertificate;
using Application.Features.WorkHistories.Commands.CreateWorkHistory;
using Application.Features.WorkHistories.Queries.GetAllWorkHistories;
using Application.Features.WorkHistories.Commands.UpdateWorkHistory;
using Application.Features.Educations.Queries.GetAllEducations;
using Application.Features.Educations.Commands.CreateEducation;
using Application.Features.Educations.Queries.GetEducationById;
using Application.Features.Educations.Commands.UpdateEducation;

//project
using Application.Features.Products.Commands.CreateProject;
using Application.Features.Projects.Commands.UpdateProject;
using Application.Features.Projects.Queries.GetAllProjects;
using Application.Features.Contacts.Queries.GetAllContacts;
using Application.Features.Contacts.Commands.CreateContact;
using Application.Features.Contacts.Commands.UpdateContact;
using Application.Features.Personnels.Queries.GetAllPersonnels;
using Application.Features.Personnels.Commands.CreatePersonnel;
using Application.Features.Personnels.Commands.UpdatePersonnel;
using Application.Features.Events.Queries.GetAllEvents;
using Application.Features.Events.Commands.CreateEvent;
using Application.Features.Events.Commands.UpdateEvent;
using Application.Features.Inventories.Queries.GetAllInventories;
using Application.Features.Inventories.Commands.CreateInventory;
using Application.Features.Inventories.Commands.UpdateInventory;

//announcement
using Application.Features.Announcements.Commands.CreateAnnouncement;
using Application.Features.Announcements.Queries.GetAllAnnouncements;
using Application.Features.Announcements.Commands.UpdateAnnouncement;
using Application.Features.Films.Queries.GetAllFilms;
using Application.Features.Films.Commands.CreateFilm;
using Application.Features.Diaries.Commands.CreateDiaries;
using Application.Features.Diaries.Queries.GetAllDiaries;
using Application.Features.Searches.Queries.GetAllSearches;
using Application.Features.Searches.Commands.CreateSearch;
using Application.Features.WatchedLists.Queries.GetAllWatchedLists;
using Application.Features.WatchedLists.Commands.CreateWatchedList;
using Application.Features.WatchLists.Queries.GetAllWatchLists;
using Application.Features.WatchLists.Commands.CreateWatchList;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Category, GetAllCategoriesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetAllCategoriesQuery, GetAllCategoriesParameter>();

            CreateMap<Address, GetAllAddressesViewModel>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<UpdateAddressCommand, Address>();
            CreateMap<GetAllAddressesQuery, GetAllAddressesParameter>();

            CreateMap<Certificate, GetAllCertificatesViewModel>().ReverseMap();
            CreateMap<CreateCertificateCommand, Certificate>();
            CreateMap<UpdateCertificateCommand, Certificate>();
            CreateMap<GetAllCertificatesQuery, GetAllCertificatesParameter>();

            CreateMap<WorkHistory, GetAllWorkHistoriesViewModel>().ReverseMap();
            CreateMap<CreateWorkHistoryCommand, WorkHistory>();
            CreateMap<UpdateWorkHistoryCommand, WorkHistory>();
            CreateMap<GetAllWorkHistoriesQuery, GetAllWorkHistoriesParameter>();

            CreateMap<Project, GetAllProjectsViewModel>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>();
            CreateMap<UpdateProjectCommand, Project>();
            CreateMap<GetAllProjectsQuery, GetAllProjectsParameter>();

            CreateMap<CreateAnnouncementCommand, Announcement>();
            CreateMap<Announcement, GetAllAnnouncementsViewModel>().ReverseMap();
            CreateMap<UpdateAnnouncementCommand, Announcement>();
            CreateMap<GetAllAnnouncementsQuery, GetAllAnnouncementsParameter>();

            CreateMap<Education, GetAllEducationsViewModel>().ReverseMap();
            CreateMap<CreateEducationCommand, Education>();
            CreateMap<UpdateEducationCommand, Education>();
            CreateMap<GetAllEducationsQuery, GetAllEventsParameter>();

            CreateMap<Event, GetAllEventsViewModel>().ReverseMap();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();
            CreateMap<GetAllEventsQuery, GetAllEventsParameter>();

            CreateMap<Personnel, GetAllPersonnelsViewModel>().ReverseMap();
            CreateMap<CreatePersonnelCommand, Personnel>();
            CreateMap<UpdatePersonnelCommand, Personnel>();
            CreateMap<GetAllPersonnelsQuery, GetAllPersonnelsParameter>();

            CreateMap<Inventory, GetAllInventoriesViewModel>().ReverseMap();
            CreateMap<CreateInventoryCommand, Inventory>();
            CreateMap<UpdateInventoryCommand, Inventory>();
            CreateMap<GetAllInventoriesQuery, GetAllInventoriesParameter>();

            CreateMap<Contact, GetAllContactsViewModel>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();
            CreateMap<GetAllContactsQuery, GetAllContactsParameter>();

            CreateMap<Diary, GetAllDiariesViewModel>();
            CreateMap<CreateDiaryCommand, Diary>();
            CreateMap<GetAllDiariesQuery, GetAllDiariesParameter>();

            CreateMap<Film, GetAllFilmsViewModel>();
            CreateMap<CreateFilmCommand, Film>();
            CreateMap<GetAllFilmsQuery, GetAllFilmsParameter>();

            CreateMap<Search, GetAllSearchesViewModel>();
            CreateMap<CreateSearchCommand, Search>();
            CreateMap<GetAllSearchesQuery, GetAllSearchesParameter>();

            CreateMap<WatchedList, GetAllWatchedListsViewModel>();
            CreateMap<CreateWatchedListCommand, WatchedList>();
            CreateMap<GetAllWatchedListsQuery, GetAllWatchedListsParameter>();

            CreateMap<WatchList, GetAllWatchListsViewModel>();
            CreateMap<CreateWatchListCommand, WatchList>();
            CreateMap<GetAllWatchListsQuery, GetAllWatchListsParameter>();



        }
    }
}
