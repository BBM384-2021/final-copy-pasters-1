using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Platform { get; set; }
        public string InvitationLink { get; set; }
        public string Address { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
    }
}