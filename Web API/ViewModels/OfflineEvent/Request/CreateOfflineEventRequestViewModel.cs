using System;

namespace Web_API.ViewModels.OfflineEvent.Request
{
    public class CreateOfflineEventRequestViewModel
    {
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int SubClubId { get; set; }
    }
}