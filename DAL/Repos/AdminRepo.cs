using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, bool>
    {
        public bool Create(Admin obj)
        {

            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Read(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin obj)
        {
            var ex = Get(obj.AdminId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }
    }
}
