using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface ICategorieService
    {
        IEnumerable<CategorieDto> Index(); 
        CategorieDto Create(CategorieDto categorie); 
        CategorieDto Edit(CategorieDto c, int id);
        void Delete(int id);
    }
}

