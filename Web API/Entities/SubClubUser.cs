using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class SubClubUser
    {
        public BanRecord BanRecord { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Post> Posts { get; set; }

        [ForeignKey("SubClub"), Column(Order=0)]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
        
        [ForeignKey("User"), Column(Order=1)]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}