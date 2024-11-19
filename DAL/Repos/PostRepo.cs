using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IRepo<Post, int, bool>
    {
        public List<Post> Get()
        {
            return db.Posts.ToList();
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public bool Create(Post obj)
        {

            db.Posts.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Posts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Post obj)
        {
            var ex = Get(obj.Post_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Post Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
