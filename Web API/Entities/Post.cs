using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}