using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AccountantRepo : Repo, IRepo<Accountant, int, bool>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Create(Accountant obj)
        {

            db.Accountants.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Accountants.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Accountant> Get()
        {
            return db.Accountants.ToList();
        }

        public Accountant Get(int id)
        {
            return db.Accountants.Find(id);
        }

        public Accountant Read(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Accountant obj)
        {
            var ex = Get(obj.A_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }
    }
}
