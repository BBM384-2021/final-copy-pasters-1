using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProofFilesUrl { get; set; }
        
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("SubClubId, UserId")]
        public SubClubUser SubClubUser { get; set; }
    }
}