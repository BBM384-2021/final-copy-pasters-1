using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class BanRecord
    {
        public int Id { get; set; }
        public int BanCount { set; get; }
        public int SubClubId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("SubClubId, UserId")]
        public SubClubUser SubClubUser { get; set; }
    }
}