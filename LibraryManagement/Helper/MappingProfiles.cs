using AutoMapper;
using LibraryManagement.Dto;
using LibraryManagement.Models;

namespace LibraryManagement.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Reader, ReaderDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Book, BookDto>();
        }
    }
}
