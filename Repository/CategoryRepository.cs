using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationsDemoExperion.Models;

namespace WebApplicationsDemoExperion.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //data fields
        private readonly DemoBlogDBContext _context;
        
        //default constructor
        //constructor based dependency injection
        public CategoryRepository(DemoBlogDBContext context)
        {
            _context = context;
        }
        #region Get ALL Categories
        public async Task<List<Category>> GetAllCategories()
        {
            if(_context != null)
            {
                //return await _context.Category.ToListAsync();
                return await _context.Category.Include(p=>p.Post).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Category
        public async Task<int> AddCategory(Category category)
        {
            if (_context != null)
            {
                await _context.Category.AddAsync(category);
                await _context.SaveChangesAsync();
                return category.CId;
            }
            return 0;
        }
        #endregion

        #region Update Category
        public async Task UpdateCategory(Category category)
        {
            if(_context != null)
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.Category.Update(category);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}