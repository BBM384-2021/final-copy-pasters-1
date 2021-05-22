using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Entities
{
    [Owned]
    public class Choice
    {
        // we may need to put id column here since there is a one to many relationship.
        public string Text { get; set; }
    }
}