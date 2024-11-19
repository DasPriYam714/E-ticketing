using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReportRepo : Repo, IRepo<Report, int, bool>
    {
        public List<Report> Get()
        {
            return db.Reports.ToList();
        }

        public Report Get(int id)
        {
            return db.Reports.Find(id);
        }

        public bool Create(Report obj)
        {

            db.Reports.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Reports.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Report obj)
        {
            var ex = Get(obj.Report_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Report Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
