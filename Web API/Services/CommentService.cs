using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.Comment.Request;
using Web_API.ViewModels.Comment.Response;

namespace Web_API.Services
{
    public interface ICommentService
    {
        public CommentResponseViewModel Create(CreateCommentRequestViewModel model);
        public IEnumerable<CommentResponseViewModel> Read();
        public CommentResponseViewModel Read(int commentId);

        public CommentResponseViewModel Update(int commentId,
            UpdateCommentRequestViewModel model);

        public void Delete(int commentId);
    }

    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CommentResponseViewModel Create(CreateCommentRequestViewModel model)
        {
            var comment = _mapper.Map<Comment>(model);
            _context.Comments.Add(comment);
            _context.SaveChanges();
            var response = _mapper.Map<CommentResponseViewModel>(comment);
            return response;
        }

        public IEnumerable<CommentResponseViewModel> Read()
        {
            var comments = _context.Comments;
            return _mapper.Map<IList<CommentResponseViewModel>>(comments);
        }

        public CommentResponseViewModel Read(int commentId)
        {
            var comment = _mapper.Map<CommentResponseViewModel>(_context.Comments.Find(commentId));
            return comment;
        }

        public CommentResponseViewModel Update(int commentId,
            UpdateCommentRequestViewModel model)
        {
            var comment = _context.Comments.Find(commentId);
            _mapper.Map(model, comment);
            _context.Comments.Update(comment);
            var updatedComment = _mapper.Map<CommentResponseViewModel>(comment);
            return updatedComment;
        }

        public void Delete(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}