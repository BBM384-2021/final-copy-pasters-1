using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<Choice> Choices { get; set; }
        
        [ForeignKey("SubClub")]
        public int SubClubId { get; set; }
        public SubClub SubClub { get; set; }
    }
}