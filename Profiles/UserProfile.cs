using AutoMapper; 
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieDto, Categorie>();
        }
    }
}