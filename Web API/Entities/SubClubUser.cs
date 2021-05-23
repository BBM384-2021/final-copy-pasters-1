using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class SubClubUser
    {
        public SubClubRole SubClubRole { get; set; }
        public int BanCount { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("SubClub"), Column(Order=0)]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
        
        [ForeignKey("User"), Column(Order=1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}