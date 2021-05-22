using System.Collections.Generic;
using Web_API.Entities;

namespace Web_API.ViewModels.Question.Response
{
    public class QuestionResponseViewModel
    {
        public int Id { get; set; }
        public int SubClubId { get; set; }
        public string Text { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}