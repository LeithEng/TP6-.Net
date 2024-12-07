using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Services
{
    public class CategorieService : ICategorieService 
    { 
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _imapper; 
        public CategorieService(ApplicationDbContext context, IMapper mapper) 
        { 
            _context = context; 
            _imapper = mapper; 
        } 
        public CategorieDto Create(CategorieDto categorie) 
        { 
//categorie.Id = Guid.NewGuid(); 
            var cat = _imapper.Map<Categorie>(categorie); 
            _context.Categories.Add(cat); 
            _context.SaveChanges(); 
            return categorie; 
        } 
        public CategorieDto Edit(CategorieDto c, int id) 
        { 
            var CatInDb=_context.Categories.SingleOrDefault(c=>c.Id==id); 
            CatInDb.Nom = c.Nom; 
            _context.SaveChanges(); 
            return _imapper.Map<Categorie, CategorieDto>(CatInDb); ; 
        } 
        public IEnumerable<CategorieDto> Index() 
        { 
            var cat = _context.Categories.ToList(); 
            var catDTO=_imapper.Map<List<CategorieDto>>(cat); 
            return catDTO; 
        } 
        public void Delete(int id) 
        { 
            var CatInDb = _context.Categories.Find(id); 
            
            _context.Categories.Remove(CatInDb); 
            _context.SaveChanges(); 
        } } }

    
