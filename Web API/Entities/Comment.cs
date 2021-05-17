using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}