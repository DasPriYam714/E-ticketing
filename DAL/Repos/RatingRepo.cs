using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RatingRepo : Repo, IRepo<Rating, int, bool>
    {
        public bool Create(Rating obj)
        {
            db.Ratings.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {

            var ex = Get(id);
            db.Ratings.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Rating> Get()
        {
            return db.Ratings.ToList();
        }

        public Rating Get(int id)
        {
            return db.Ratings.Find(id);
        }

        public Rating Read(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rating obj)
        {
            var ex = Get(obj.R_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }
    }
}
