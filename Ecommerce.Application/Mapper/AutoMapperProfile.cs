using AutoMapper;
using Ecommerce.Dtos.Author;
using Ecommerce.Dtos.Book;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<BookCreateViewModel, Book>().ReverseMap();
            CreateMap<Book, BookDetailsViewModel>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ReverseMap();
            CreateMap<Book, BookListViewModel>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ReverseMap();
            CreateMap<BookEditViewModel, Book>().ReverseMap();
            CreateMap<AuthorListViewModel, Author>().ReverseMap();
        }
    }
}
