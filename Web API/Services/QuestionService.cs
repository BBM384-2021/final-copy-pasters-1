using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.Question.Request;
using Web_API.ViewModels.Question.Response;

namespace Web_API.Services
{
    public interface IQuestionService
    {
        public QuestionResponseViewModel Create(CreateQuestionRequestViewModel model);
        public IEnumerable<QuestionResponseViewModel> Read();
        public QuestionResponseViewModel Read(int questionId);

        public QuestionResponseViewModel Update(int questionId,
            UpdateQuestionRequestViewModel model);

        public void Delete(int questionId);
    }

    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QuestionResponseViewModel Create(CreateQuestionRequestViewModel model)
        {
            var question = _mapper.Map<Question>(model);
            _context.Questions.Add(question);
            _context.SaveChanges();
            var response = _mapper.Map<QuestionResponseViewModel>(question);
            return response;
        }

        public IEnumerable<QuestionResponseViewModel> Read()
        {
            var questions = _context.Questions;
            return _mapper.Map<IList<QuestionResponseViewModel>>(questions);
        }

        public QuestionResponseViewModel Read(int questionId)
        {
            var question = _mapper.Map<QuestionResponseViewModel>(_context.Questions.Find(questionId));
            return question;
        }

        public QuestionResponseViewModel Update(int questionId,
            UpdateQuestionRequestViewModel model)
        {
            var question = _context.Questions.Find(questionId);
            _mapper.Map(model, question);
            _context.Questions.Update(question);
            var updatedQuestion = _mapper.Map<QuestionResponseViewModel>(question);
            return updatedQuestion;
        }

        public void Delete(int questionId)
        {
            var question = _context.Questions.Find(questionId);
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}