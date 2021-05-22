using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class OnlineEvent
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public string InvitationLink { get; set; }
        public Event Event { get; set; }

        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
    }
}