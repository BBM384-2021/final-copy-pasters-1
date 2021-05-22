using System.Collections.Generic;
using Web_API.ViewModels.Comment.Response;

namespace Web_API.ViewModels.Post.Response
{
    public class PostResponseViewModel
    {
        public int Id { get; set; }
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public ICollection<CommentResponseViewModel> Comments { get; set; }
    }
}