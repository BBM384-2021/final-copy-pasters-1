namespace Web_API.ViewModels.Comment.Request
{
    public class CreateCommentRequestViewModel
    {
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}