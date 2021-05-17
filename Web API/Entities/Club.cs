using System.Collections.Generic;

namespace Web_API.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<SubClub> SubClubs { get; set; }
    }
}