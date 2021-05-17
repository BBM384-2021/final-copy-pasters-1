using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class ReviewAndRate
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float Rate { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
    }
}