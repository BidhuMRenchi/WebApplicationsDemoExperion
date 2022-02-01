using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationsDemoExperion.Models;
using WebApplicationsDemoExperion.Repository;

namespace WebApplicationsDemoExperion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        //data fields 
        private readonly ICategoryRepository _categoryRepository;
        
        //constructor injection
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        //[Authorize]
        [Route("GetCategories")]
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #region Get All Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryAll()
        {
            return await _categoryRepository.GetAllCategories();
        }
        #endregion

        #region Add Category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _categoryRepository.AddCategory(category);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateCategory(category);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
