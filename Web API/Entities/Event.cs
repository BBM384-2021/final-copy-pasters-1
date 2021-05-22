using System;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Entities
{
    [Owned]
    public class Event
    {
        public string Type { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
    }
}