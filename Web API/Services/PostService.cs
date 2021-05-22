using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.Post.Request;
using Web_API.ViewModels.Post.Response;

namespace Web_API.Services
{
    public interface IPostService
    {
        public PostResponseViewModel Create(CreatePostRequestViewModel model);
        public IEnumerable<PostResponseViewModel> Read();
        public PostResponseViewModel Read(int postId);

        public PostResponseViewModel Update(int postId,
            UpdatePostRequestViewModel model);

        public void Delete(int postId);
    }

    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PostService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PostResponseViewModel Create(CreatePostRequestViewModel model)
        {
            var post = _mapper.Map<Post>(model);
            _context.Posts.Add(post);
            _context.SaveChanges();
            var response = _mapper.Map<PostResponseViewModel>(post);
            return response;
        }

        public IEnumerable<PostResponseViewModel> Read()
        {
            var posts = _context.Posts;
            return _mapper.Map<IList<PostResponseViewModel>>(posts);
        }

        public PostResponseViewModel Read(int postId)
        {
            var post = _mapper.Map<PostResponseViewModel>(_context.Posts.Find(postId));
            return post;
        }

        public PostResponseViewModel Update(int postId,
            UpdatePostRequestViewModel model)
        {
            var post = _context.Posts.Find(postId);
            _mapper.Map(model, post);
            _context.Posts.Update(post);
            var updatedPost = _mapper.Map<PostResponseViewModel>(post);
            return updatedPost;
        }

        public void Delete(int postId)
        {
            var post = _context.Posts.Find(postId);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}