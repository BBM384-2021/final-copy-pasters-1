using System;

namespace Web_API.ViewModels.OfflineEvent.Request
{
    public class UpdateOfflineEventRequestViewModel
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
    }
}