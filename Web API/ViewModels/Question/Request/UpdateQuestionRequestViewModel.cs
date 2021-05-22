using System.Collections.Generic;
using Web_API.Entities;

namespace Web_API.ViewModels.Question.Request
{
    public class UpdateQuestionRequestViewModel
    {
        public string Text { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}