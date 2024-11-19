using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, int, bool>
    {
        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public bool Create(Comment obj)
        {

            db.Comments.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Comments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Comment obj)
        {
            var ex = Get(obj.Comment_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Comment Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
