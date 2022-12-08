using BookStore.API.AutoMapper;
using BookStore.API.Data;
using BookStore.API.Interface;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Services;
using BookStore.API.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JwtTokenGenerator = BookStore.API.Services.Auth.JwtTokenGenerator;

namespace BookStore.API.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IZoneRepository, ZoneRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IContantUsRepository, ContantUsRepository>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITranslatorRepository, TranslatorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookSuggestionRepository, BookSuggestionRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IStaticPageRepository, StaticPageRepository>();
            services.AddTransient<IBookReviewRepository , BookReviewRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();


            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddDefaultTokenProviders();





            return services;
        }
    }
}
