using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationsDemoExperion.Models;

namespace WebApplicationsDemoExperion.Repository
{
    public interface ICategoryRepository
    {
        //get all Categories
        Task<List<Category>> GetAllCategories();

        //Add Category ----create ---insert
        Task<int> AddCategory(Category category);

        //Update Category
        Task UpdateCategory(Category category);
    }
}
