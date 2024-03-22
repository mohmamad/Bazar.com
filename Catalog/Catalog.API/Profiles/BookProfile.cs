using AutoMapper;
using Catalog.API.DTOs;
using Catalog.DataAccess.Entities;

namespace Catalog.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookInfoDto>();
            CreateMap<Book, BookSearchDto>();
        }
    }
}
