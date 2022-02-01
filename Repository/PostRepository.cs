using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationsDemoExperion.Models;
using WebApplicationsDemoExperion.ViewModel;

namespace WebApplicationsDemoExperion.Repository
{
    public class PostRepository : IPostRepository
    {
        //data fields
        private readonly DemoBlogDBContext _context;
        //default constructor
        //constructor based dependency injection
        public PostRepository(DemoBlogDBContext context1)
        {
            _context = context1;
        }
        #region view posts based on view model
        public async Task<List<PostViewModel>> GetAllPosts()
        {
            if (_context != null)
            {
                //LINQ
                //JOIN POST and CAtEGORY
                return await (
                    from p in _context.Post
                    from c in _context.Category
                    where p.CId == c.CId
                    select new PostViewModel
                    {
                        PId = p.PId,
                        Title = p.Title,
                        Description = p.Description,
                        CId = p.CId,
                        CategoryName = c.Name,
                        CreatedDate = p.CreatedDate
                    }
                    ).ToListAsync();
            }
            return null;
        }
        #endregion

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if (_context != null)
            {
                //LINQ
                //JOIN POST and CAtEGORY
                return await (
                    from p in _context.Post
                    from c in _context.Category
                    where p.CId == postId
                    select new PostViewModel
                    {
                        PId = p.PId,
                        Title = p.Title,
                        Description = p.Description,
                        CId = p.CId,
                        CategoryName = c.Name,
                        CreatedDate = p.CreatedDate
                    }
                    ).FirstOrDefaultAsync();
            }
            return null;
        }
        //Add Post
        #region
        public async Task<int> AddPost(Post post)
        {
            if (_context != null)
            {
                await _context.Post.AddAsync(post);
                await _context.SaveChangesAsync();
                return post.PId;
            }
            return 0;
        }
        #endregion

        //Update Post
        #region Update Post
        public async Task UpdatePost(Post post)
        {
            if (_context != null)
            {
                _context.Entry(post).State = EntityState.Modified;
                _context.Post.Update(post);
                await _context.SaveChangesAsync(); //Commit the transaction

            }
        }
        #endregion
    }
}
