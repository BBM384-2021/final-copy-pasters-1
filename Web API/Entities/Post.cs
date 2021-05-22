using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("SubClubId, UserId")]
        public SubClubUser SubClubUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}