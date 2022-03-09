using AutoMapper;
using DBook.Data.Entity;

namespace DBook.Models
{
    public class ProfileMap:Profile
    {
        public ProfileMap()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
