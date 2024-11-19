using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        public static List<ReportDTO> Get()
        {

            var data = DataAccessFactory.ReportData().Get();
            return Convert(data);

        }

        public static ReportDTO Get(int id)
        {
            return Convert(DataAccessFactory.ReportData().Get(id));
        }
        public static bool Create(ReportDTO report)
        {
            var data = Convert(report);
            var res = DataAccessFactory.ReportData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(ReportDTO report)
        {
            var data = Convert(report);
            var res = DataAccessFactory.ReportData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ReportData().Delete(id);
        }

        static List<ReportDTO> Convert(List<Report> reports)
        {
            var data = new List<ReportDTO>();
            foreach (var report in reports)
            {
                data.Add(Convert(report));
            }
            return data;

        }
        static Report Convert(ReportDTO report)
        {
            return new Report()
            {
                Report_Id = report.Report_Id,
                Report_Date = report.Report_Date,
                Income = report.Income,
                Expense = report.Expense,
                T_ID = report.T_ID,
                B_ID = report.B_ID
            };
        }
        static ReportDTO Convert(Report report)
        {
            return new ReportDTO()
            {
                Report_Id = report.Report_Id,
                Report_Date = report.Report_Date,
                Income = report.Income,
                Expense = report.Expense,
                T_ID = report.T_ID,
                B_ID = report.B_ID
            };
        }
    }
}
