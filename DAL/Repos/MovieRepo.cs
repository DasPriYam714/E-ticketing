using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieRepo : Repo, IRepo<Movie, int, bool>
    {
        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Movies.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public Movie Read(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Movie obj)
        {
            var ex = Get(obj.M_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }
    }
}
