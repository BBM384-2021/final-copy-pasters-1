using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class OfflineEvent
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Event Event { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
    }
}