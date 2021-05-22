using System;

namespace Web_API.ViewModels.OnlineEvent.Request
{
    public class UpdateOnlineEventRequestViewModel
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Platform { get; set; }
        public string InvitationLink { get; set; }
    }
}