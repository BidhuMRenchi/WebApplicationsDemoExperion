using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationsDemoExperion.Models;
using WebApplicationsDemoExperion.Repository;
using WebApplicationsDemoExperion.ViewModel;

namespace WebApplicationsDemoExperion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        //data fields 
        private readonly IPostRepository _postRepository;

        //constructor injection
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        #region Add Post
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _postRepository.AddPost(post);
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
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _postRepository.UpdatePost(post);
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

        #region GetAllPost ---2- ViewModel 

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _postRepository.GetAllPosts();
                if(posts == null)
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region GetPost ---2--- ViewModel
        [HttpGet("{id}")]
        //[Route("id")]
        public async Task<IActionResult> GetPost(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            try
            {
                var post = await _postRepository.GetPost(id);
                if(post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}


/*{
    "PostId": 1,
        "Title": "Ashwin My Name",
        "CreatedDate": "2020-12-12T00:00:00",
        "Description": "My Movie Nice",
        "CategoryId": 1,
        "CreatedDate1": "2020-12-12T00:00:00",
        "Category": null
    }*/