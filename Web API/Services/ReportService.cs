using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.Report.Request;
using Web_API.ViewModels.Report.Response;

namespace Web_API.Services
{
    public interface IReportService
    {
        public ReportResponseViewModel Create(CreateReportRequestViewModel model);
        public IEnumerable<ReportResponseViewModel> Read();
        public ReportResponseViewModel Read(int reportId);

        public ReportResponseViewModel Update(int reportId,
            UpdateReportRequestViewModel model);

        public void Delete(int reportId);
    }

    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReportService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReportResponseViewModel Create(CreateReportRequestViewModel model)
        {
            var report = _mapper.Map<Report>(model);
            _context.Reports.Add(report);
            _context.SaveChanges();
            var response = _mapper.Map<ReportResponseViewModel>(report);
            return response;
        }

        public IEnumerable<ReportResponseViewModel> Read()
        {
            var reports = _context.Reports;
            return _mapper.Map<IList<ReportResponseViewModel>>(reports);
        }

        public ReportResponseViewModel Read(int reportId)
        {
            var report = _mapper.Map<ReportResponseViewModel>(_context.Reports.Find(reportId));
            return report;
        }

        public ReportResponseViewModel Update(int reportId,
            UpdateReportRequestViewModel model)
        {
            var report = _context.Reports.Find(reportId);
            _mapper.Map(model, report);
            _context.Reports.Update(report);
            var updatedReport = _mapper.Map<ReportResponseViewModel>(report);
            return updatedReport;
        }

        public void Delete(int reportId)
        {
            var report = _context.Reports.Find(reportId);
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }
    }
}