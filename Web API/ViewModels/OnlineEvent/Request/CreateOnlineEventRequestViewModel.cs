using System;

namespace Web_API.ViewModels.OnlineEvent.Request
{
    public class CreateOnlineEventRequestViewModel
    {
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Platform { get; set; }
        public string InvitationLink { get; set; }
        public int SubClubId { get; set; }
    }
}