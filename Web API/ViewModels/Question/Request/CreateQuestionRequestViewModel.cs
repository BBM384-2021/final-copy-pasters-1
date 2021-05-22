using System.Collections.Generic;
using Web_API.Entities;

namespace Web_API.ViewModels.Question.Request
{
    public class CreateQuestionRequestViewModel
    {
        public string Text { get; set; }
        public int SubClubId { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}