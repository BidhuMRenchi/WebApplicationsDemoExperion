using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationsDemoExperion.Models;
using WebApplicationsDemoExperion.ViewModel;

namespace WebApplicationsDemoExperion.Repository
{
    public interface IPostRepository
    {

        //get posts
        //Task<List<Post>> GetAllPosts();
        //Gell all posts -- view model
        Task<List<PostViewModel>> GetAllPosts();

        //get post by id  -- viewModel
        Task<PostViewModel> GetPost(int? postId);

        //add post
        Task<int> AddPost(Post post);

        //update post
        Task UpdatePost(Post post);
    }
}
