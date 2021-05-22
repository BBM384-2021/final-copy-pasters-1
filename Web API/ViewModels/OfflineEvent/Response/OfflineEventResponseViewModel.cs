using System;

namespace Web_API.ViewModels.OfflineEvent.Response
{
    public class OfflineEventResponseViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int SubClubId { get; set; }   
    }
}