using AutoMapper;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categorie, CategorieDto>().ReverseMap();
        }
    }
}