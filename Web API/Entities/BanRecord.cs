using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class BanRecord
    {
        public int Id { get; set; }
        public int BanCount { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}