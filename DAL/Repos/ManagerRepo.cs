using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ManagerRepo : Repo, IRepo<Manager, int, bool>
    {
        public List<Manager> Get()
        {
            return db.Managers.ToList();
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public bool Create(Manager obj)
        {

            db.Managers.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Managers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Manager obj)
        {
            var ex = Get(obj.Manager_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Manager Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
