namespace Web_API.ViewModels.Post.Request
{
    public class CreatePostRequestViewModel
    {
        public string Text { get; set; }
        public int SubClubId { get; set; }
        public int UserId { get; set; }
    }
}