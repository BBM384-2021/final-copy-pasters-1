using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class SubClub
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public float AverageRate { get; set; }
        
        [ForeignKey("Club")]
        public int ClubId { get; set; }
        public Club Club { get; set; }
        
        public ICollection<ReviewAndRate> ReviewAndRates { get; set; }
        public ICollection<OfflineEvent> OfflineEvents { get; set; }
        public ICollection<OnlineEvent> OnlineEvents { get; set; }
        // public ICollection<Report> Reports { get; set; }
        public ICollection<Question> Questions { get; set; }
        // public ICollection<Post> Posts { get; set; }
        // public ICollection<BanRecord> BanRecords { get; set; }
        // public ICollection<User> Users { get; set; }
        public ICollection<SubClubUser> SubClubUsers { get; set; }
    }
}