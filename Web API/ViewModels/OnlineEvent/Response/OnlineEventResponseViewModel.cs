using System;

namespace Web_API.ViewModels.OnlineEvent.Response
{
    public class OnlineEventResponseViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Platform { get; set; }
        public string InvitationLink { get; set; }
        public int SubClubId { get; set; } 
    }
}