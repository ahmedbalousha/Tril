using AutoMapper;
using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.ViewModels;
using BookStore.DTOs;

namespace BookStore.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            CreateMap<Author, AuthorViewModel>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
            CreateMap<Author, UpdateAuthorDto>();

            CreateMap<Zone, ZoneViewModel>();
            CreateMap<CreateZoneDto, Zone>();
            CreateMap<UpdateZoneDto, Zone>();
            CreateMap<Zone, UpdateZoneDto>();

            CreateMap<Address, AddressViewModel>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, UpdateAddressDto>();

            CreateMap<Publisher, PublisherViewModel>();
            CreateMap<CreatePublisherDto, Publisher>().ForMember(x => x.Logo, x => x.Ignore()); 
            CreateMap<UpdatePublisherDto, Publisher>();
            CreateMap<Publisher, UpdatePublisherDto>();
            
            CreateMap<ContantUs, ContantUsViewModel>();
            CreateMap<CreateContantUsDto, ContantUs>();
            CreateMap<UpdateContantUsDto, ContantUs>();
            CreateMap<ContantUs, UpdateContantUsDto>();
            
            CreateMap<Translator, TranslatorViewModel>();
            CreateMap<CreateTranslatorDto, Translator>();
            CreateMap<UpdateTranslatorDto, Translator>();
            CreateMap<Translator, UpdateTranslatorDto>();

            CreateMap<Book, BookViewModel>();
            CreateMap<CreateBookDto, Book>().ForMember(x => x.Image, x => x.Ignore());
            CreateMap<UpdateBookDto, Book>().ForMember(x => x.Image, x => x.Ignore());
            CreateMap<Book, UpdateBookDto>().ForMember(x => x.Image, x => x.Ignore());
            
            CreateMap<BookSuggestion, BookSuggestionViewModel>();
            CreateMap<CreateBookSuggestionDto, BookSuggestion>();
            CreateMap<UpdateBookSuggestionDto, BookSuggestion>();
            CreateMap<BookSuggestion, UpdateBookSuggestionDto>();

            CreateMap<StaticPage, StaticPageViewModel>();
            CreateMap<CreateStaticPageDto, StaticPage>();
            CreateMap<UpdateStaticPageDto, StaticPage>();
            CreateMap<StaticPage, UpdateStaticPageDto>();


            CreateMap<RegisterRequestDto, AppUser>()
               .ForMember(x => x.SecurityStamp, x => x.Ignore());
            

            CreateMap<BookReview, BookReviewViewModel>();
            CreateMap<CreateBookReviewDto, BookReview>();
            CreateMap<UpdateBookReviewDto, BookReview>();
            CreateMap<BookReview, UpdateBookReviewDto>();
            
            CreateMap<Sale, SaleViewModel>();
            CreateMap<CreateSaleDto, Sale>();
            //CreateMap<UpdateSaleDto, Sale>();
            //CreateMap<Sale, UpdateSaleDto>();

        }


    }
}
