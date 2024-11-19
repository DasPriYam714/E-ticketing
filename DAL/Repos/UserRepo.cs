using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth<bool>
    {
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Create(User obj)
        {

            db.Users.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(User obj)
        {
            var ex = Get(obj.U_ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.U_Name.Equals(username) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }


        public User Read(string id)
        {
            return db.Users.Find(id);
        }
    }
}
