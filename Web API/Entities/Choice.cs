using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}